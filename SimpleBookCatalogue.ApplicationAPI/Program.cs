using Microsoft.EntityFrameworkCore;
//using SimpleBookCatalogue.Application.Interfaces;
using SimpleBookCatalogue.ApplicationAPI.Components;
using SimpleBookCatalogue.ApplicationAPI.Interfaces;
using SimpleBookCatalogue.Infrastructure.Context;
using SimpleBookCatalogue.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<SimpleBookCatalogueDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SimpleBookCatalogueConnection"));
});

builder.Services.AddScoped<IBookRepository, BookRepository>();

//DI For the Services
builder.Services.AddTransient<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
