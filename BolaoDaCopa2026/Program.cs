using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Data.Seeds;
using BolaoDaCopa2026.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

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



using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BolaoContext>();
    JogosSeed.Seed(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "movie",
    pattern: "{controller=Movie}/{action=Filme}/{id?}"
);

app.MapControllerRoute(
    name: "apostas",
    pattern: "apostas/{action=Index}/{id?}",
    defaults: new { controller = "Apostas" });


app.Run();

