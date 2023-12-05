using medcenter_backend.Models;
using medcenter_backend.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner.
builder.Services.AddControllersWithViews();

object value = builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/Usuarios/AccessDenied/";
        options.LoginPath = "/Usuarios/Login/";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("MedicPolicy", policy => policy.RequireRole("Medico"));
    options.AddPolicy("ClinicPolicy", policy => policy.RequireRole("Clinica"));
});

builder.Services.AddScoped<EmailSender>();

var app = builder.Build();

// Configure o pipeline de solicitação HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Paciente",
    pattern: "Paciente/Index",
    defaults: new { controller = "Paciente", action = "Index" }
);

app.MapControllerRoute(
    name: "ClinicaEdit",
    pattern: "Clinicas/Edit/{id?}",
    defaults: new { controller = "Clinicas", action = "Edit" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "consultas",
    pattern: "Consultas/{action=Index}/{id?}",
    defaults: new { controller = "Consultas" });

app.MapControllerRoute(
    name: "RedefinicaoSenha",
    pattern: "RedefinirSenha/{action}/{token?}",
    defaults: new { controller = "RedefinirSenha", action = "EsqueciMinhaSenha" });

app.Run();
