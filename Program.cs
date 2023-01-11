using DecaPlayStore.Data;
using DecaStore.Data;
using DecaStore.Data.IRepository;
using DecaStore.Data.IServices;
using DecaStore.Data.Services;
using DecaStore.Data.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//DbContext configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
           ));
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();
//Seed databse
SeedIntializer.SeedData(app);

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
