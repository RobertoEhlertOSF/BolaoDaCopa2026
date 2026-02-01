using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Data.Seeds;
using BolaoDaCopa2026.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache(); // para usar session em memória

builder.Services.AddScoped<JogoService>();
builder.Services.AddScoped<SelecaoService>();
builder.Services.AddScoped<ApostaService>();
builder.Services.AddScoped<PontuacaoService>();



builder.Services.AddSession(options =>
{

    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
    });

builder.Services.AddDbContext<BolaoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BolaoConnection")));

builder.Services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();

builder.Services.AddHttpClient();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}



using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BolaoContext>();
    JogosSeed.Seed(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "conta",
    pattern: "Conta/{action=Login}/{id?}",
    defaults: new { controller = "Conta" });

app.MapControllerRoute(
    name: "apostas",
    pattern: "apostas/{action=Index}/{id?}",
    defaults: new { controller = "Apostas" });


app.Run();

