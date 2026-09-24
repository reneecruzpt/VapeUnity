using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
//using VapeUnity.Areas.Identity.Data;
using VapeUnity.Models;
using SendGrid.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using VapeUnity.Services;
using System.Web;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using VapeUnity.Services.VapeUnity.Services;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ContextoConnection") ?? throw new InvalidOperationException("Connection string 'ContextoConnection' not found.");
//var connectionString = builder.Configuration.GetConnectionString("IdentidadeDBContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentidadeDBContextConnection' not found.");

//

//
// ...


var googleApiKey = builder.Configuration["Google:GeocodingApiKey"] ?? "";
builder.Services.AddSingleton<GeocodingService>(new GeocodingService(googleApiKey));

// ...


//

//builder.Services.AddSingleton<IEmailSender, IEmailSender>();

builder.Services.AddSendGrid(options =>
{
    options.ApiKey = builder.Configuration["SendGrid:ApiKey"];
});

var sendGridApiKey = builder.Configuration["SendGrid:ApiKey"];

builder.Services.AddTransient<IEmailSender>(s => new EmailService(sendGridApiKey));

// Add services to the container.
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "AspNetCore.Identity.Application";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Conta/Login"; // Página de login
    options.LogoutPath = "/Conta/Sair"; // Página de logout
    options.AccessDeniedPath = "/Acesso/AcessoNegado"; // Página de acesso negado
    options.SlidingExpiration = true;
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ModeratorOnly", policy => policy.RequireRole("Moderator"));
    // Outras políticas e funções aqui
});


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Configurações do ASP.NET Identity aqui
    options.SignIn.RequireConfirmedEmail = true; // Requer confirmação de e-mail
})
    .AddEntityFrameworkStores<Contexto>()
    .AddDefaultTokenProviders();

//builder.Services.AddDefaultIdentity<VapeUnityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<IdentidadeDBContext>();


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("pt-BR"); // Defina a cultura desejada, como "pt-BR" para português do Brasil
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
    options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
});

var configuration = builder.Configuration;
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = configuration["Authentication:Google:ClientId"];
        options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
    });

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<Contexto>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ContextoConnection");
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 26)));
});

/*
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Contexto>();
*/



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var user = await userManager.FindByIdAsync("2be7f7de-9128-415b-b5c6-1b17d964db33");
    if (user != null)
    {
        // Verifique se a função "Admin" existe; se não existir, crie-a
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        await userManager.AddToRoleAsync(user, "Admin");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

var supportedCultures = new[]
{
    new CultureInfo("pt-PT")
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("pt-PT"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
/*
app.MapControllerRoute(
    name: "RegisterClient",
    pattern: "/Account/Register",
    defaults: new { controller = "Account", action = "Register" }
).RequireAuthorization();
*/
app.MapControllerRoute(
    name: "Logout",
    pattern: "/Conta/Sair",
    defaults: new { controller = "Conta", action = "Sair" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "carrinho",
    pattern: "/Carrinho/AdicionarAoCarrinho",
    defaults: new { controller = "Carrinho", action = "AdicionarAoCarrinho" }
).RequireAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();

    endpoints.MapAreaControllerRoute(
    name: "Identity",
    areaName: "Identity",
    pattern: "Identity/{controller=Account}/{action=Login}/{id?}");

    endpoints.MapAreaControllerRoute(
        name: "IdentityEmail",
        areaName: "Identity",
        pattern: "Identity/{controller=Account}/{action=ConfirmEmail}/{userId?}/{code?}");

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );


});
app.Run();
