using OnlineShopBlazor.Components;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System.Configuration;
using OnlineShopBlazor.Models.Validations;
using OnlineShopBlazor.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<OnlineShopBlazor.Models.Db.OnlineShopContext>();
builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddBlazorBootstrap();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RecoveryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ResetPasswordValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<OrderValidator>();
//--------------------------------------------
// --- Authentication Configuration START ---
builder.Services.AddAuthentication("MyCookieAuth") // схема аутентификации
    .AddCookie("MyCookieAuth", options =>
    {
        options.Cookie.Name = "OnlineShop.Auth";
        options.LoginPath = "/login"; // куда перенаправлять при необходимости логина
        options.ExpireTimeSpan = TimeSpan.FromDays(30); // срок жизни cookie
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<LoginService>();
builder.Services.AddRazorPages();
//--------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();



app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapRazorPages();
app.UseAntiforgery();

app.Run();
