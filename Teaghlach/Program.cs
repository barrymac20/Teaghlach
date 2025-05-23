using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Teaghlach.Data;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Server;
using Teaghlach.Components;

var builder = WebApplication.CreateBuilder(args);

//  Configure MySQL for your app's data
builder.Services.AddDbContextFactory<TeaghlachContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("TeaghlachContext")
            ?? throw new InvalidOperationException("Connection string 'TeaghlachContext' not found."),
        new MySqlServerVersion(new Version(8, 0, 42)) // Match your MySQL version
    ));

//  Add services
builder.Services.AddMudServices();
builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//  Optional: If you're still using AuthenticationStateProvider
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

var app = builder.Build();

//  HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // You can keep migrations endpoint if you like
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
