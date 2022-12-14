using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Repository;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Services.Implements;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Context DB SQL Server
builder.Services.AddDbContext<ContextoDatabase>
    (options => options.UseSqlServer("Server=DESKTOP-267CQMF\\SQLEXPRESS;Database=ListaCompras;User Id=sa;Password=admin;"));

/*
 * Dependency Injection
 */

// Repositories
builder.Services.AddScoped<CategoriaRepository, CategoriaRepository>();

// Services
builder.Services.AddScoped<ICategoriasService, CategoriasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
