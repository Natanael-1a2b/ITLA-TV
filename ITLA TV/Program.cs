using Database.ItlaTVContexts;
using Microsoft.EntityFrameworkCore;
using Logica_de_Negocio.Servicies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConexion");
builder.Services.AddDbContext<AppContexts>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddScoped<SerieService>();
builder.Services.AddScoped<ProductoraService>();
builder.Services.AddScoped<GeneroService>();

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
