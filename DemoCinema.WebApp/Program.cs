using DemoCinema.BLL.Helpers;
using DemoCinema.BLL.Interfaces;
using DemoCinema.BLL.Services;
using DemoCinema.DAL;
using DemoCinema.DAL.Interfaces;
using DemoCinema.DAL.Repositories;
using DemoCinema.WebApp.Tools;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Définir la configuration de l'injection de dépendences (DI)
// Trois config possible 
// - Singleton : Une seul instance
// - Scoped : Une instance par requete (Traitement de celle-ci)
// - Transient : Une nouvelle instance à chaque appel

#region Service d'exemple pour la demo
// Ecriture en typeof
/* 
builder.Services.AddSingleton(typeof(DemoSingletonTool));
builder.Services.AddScoped(typeof(DemoScopedTool));
builder.Services.AddTransient(typeof(DemoTransientTool));
*/
// Ecriture en générique
builder.Services.AddSingleton<DemoSingletonTool>();
builder.Services.AddScoped<DemoScopedTool>();
builder.Services.AddTransient<DemoTransientTool>();
#endregion

// Injection des services
builder.Services.AddSingleton<DataStaticContext>();
builder.Services.AddScoped<IMovieRepository, MovieStaticRepository>();
builder.Services.AddScoped<IScreeningRepository, ScreeningStaticRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IScreeningService, ScreeningService>();

builder.Services.AddTransient<IHasherHelper, HasherHelper>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

// Configuration de l'authentification
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // Options pour l'authentification
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/Denied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

        // Options pour le cookies
        options.Cookie.Name = "ExoCine.JadoreLodeurDesCookiesAuPetitMatin";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
