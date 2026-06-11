using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Data.Seeds;
using BolaoDaCopa2026.Models;
using BolaoDaCopa2026.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache(); // para usar session em memória

builder.Services.AddScoped<JogoService>();
builder.Services.AddScoped<SelecaoService>();
builder.Services.AddScoped<ApostaService>();
builder.Services.AddScoped<ApostaPrazoService>();
builder.Services.AddScoped<PontuacaoService>();
builder.Services.AddScoped<HorarioOficialService>();

builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings")
);

builder.Services.AddScoped<IEmailService, SmtpEmailService>();
builder.Services.AddScoped<SmtpEmailService>();

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

var sqliteDbPath = ResolveSqliteDatabasePath(
    builder.Configuration,
    builder.Environment.ContentRootPath);
var sqliteDirectory = Path.GetDirectoryName(sqliteDbPath)
    ?? throw new InvalidOperationException("Não foi possível determinar o diretório do banco SQLite.");

Directory.CreateDirectory(sqliteDirectory);

builder.Services.AddDbContext<BolaoContext>(options =>
    options.UseSqlite($"Data Source={sqliteDbPath}"));

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
    var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher<Usuario>>();

    context.Database.Migrate();
    UsuarioSeed.Seed(context, builder.Configuration, app.Environment, passwordHasher);
    JogosSeed.Seed(context);
    JogosSegundaFaseSeed.Seed(context);
    JogosOitavasSeed.Seed(context);
    JogosQuartasSeed.Seed(context);
    JogosSemifinalSeed.Seed(context);
    JogosTerceiroLugarSeed.Seed(context);
    JogosFinalSeed.Seed(context);

    var habilitarSeedFuncional = builder.Configuration.GetValue(
        "SeedSettings:EnableFunctionalTestSeed",
        app.Environment.IsDevelopment());

    if (habilitarSeedFuncional)
    {
        TesteFuncionalSeed.Seed(context);
    }
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

static string ResolveSqliteDatabasePath(IConfiguration configuration, string contentRootPath)
{
    var configuredPath = configuration["Sqlite:DbPath"];

    if (string.IsNullOrWhiteSpace(configuredPath))
    {
        var connectionString = configuration.GetConnectionString("BolaoConnection");

        if (!string.IsNullOrWhiteSpace(connectionString))
        {
            var sqliteConnection = new SqliteConnectionStringBuilder(connectionString);
            configuredPath = sqliteConnection.DataSource;
        }
    }

    var dbPath = string.IsNullOrWhiteSpace(configuredPath)
        ? Path.Combine("App_Data", "bolao.db")
        : configuredPath.Trim();

    return Path.IsPathRooted(dbPath)
        ? dbPath
        : Path.GetFullPath(Path.Combine(contentRootPath, dbPath));
}

