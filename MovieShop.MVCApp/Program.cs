using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Contracts.Repositories;
using MovieShop.Core.Contracts.Services;
using MovieShop.Infrastructure.Data;
using MovieShop.Infrastructure.Repositories;
using MovieShop.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICastService, CastService>();
builder.Services.AddScoped<ICastRepository, CastRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddDbContext<MovieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieShopConnection"));
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();