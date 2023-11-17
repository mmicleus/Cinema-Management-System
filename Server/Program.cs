using BlazorCinemaMS.Server.Helper.Utility;
using BlazorCinemaMS.Server.Services.NetworkService;
using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;
using CinemaMS.Data;
using CinemaMS.Helper;
using CinemaMS.Interfaces;
using CinemaMS.Models;
using CinemaMS.Repositories;
using Mapster;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllersWithViews();




builder.Services.AddRazorPages();




builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IMoviesService,MoviesService>();
builder.Services.AddScoped<IUtilityService, UtilityService>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);






// --------------------------------------- Identity Framework related ----------------------------------------


//make sure this line of code is just below the "AddDbContext" one
builder.Services.AddIdentity<AppUser, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddMemoryCache();

//This gives us cookie authentication
builder.Services.AddSession();



//builder.Services.AddControllers().AddJsonOptions(x =>
//                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

// --------------------------------------- End Of Identity Framework related ----------------------------------------


builder.Services.AddHttpClient<IMoviesService, MoviesService>(
    client =>
    client.BaseAddress = new Uri(builder.Configuration.GetSection("MoviesApiBaseAddress").Value)
    // client.BaseAddress = new Uri("https://api.themoviedb.org/3/")
    );


ConfigureMapster();


var app = builder.Build();


if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
   // await DataSeeder.SeedUsersAndRolesAsync(app);
    SeedData(app);
}


void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();


void ConfigureMapster()
{
	TypeAdapterConfig<BranchVM, Branch>
		.NewConfig()
		.Map(dest => dest.ImageUrl, src => src.Image);
}


