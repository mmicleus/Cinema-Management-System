using BlazorCinemaMS.Server.Helper.Utility;
using BlazorCinemaMS.Server.Repositories.SharedRepository;
using BlazorCinemaMS.Server.Services.EmailService;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllersWithViews();


builder.Services.AddRazorPages();




builder.Services.AddTransient<DataSeeder>();
builder.Services.AddTransient<IEmailService,EmailService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IMoviesService,MoviesService>();
builder.Services.AddScoped<IUtilityService, UtilityService>();

builder.Services.AddScoped<ISharedRepository, SharedRepository>();




builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
  //  options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
);

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();






// --------------------------------------- Identity Framework related ----------------------------------------


//make sure this line of code is just below the "AddDbContext" one
//builder.Services.AddIdentity<AppUser, IdentityRole>()
//        .AddEntityFrameworkStores<AppDbContext>();




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

//builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


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


//Make sure that this is above UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");


//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//    var roles = new[] { "Admin", "Manager", "Member" };

//    foreach(var role in roles)
//    {
//        if(!await roleManager.RoleExistsAsync(role))
//        {
//            await roleManager.CreateAsync(new IdentityRole(role));
//        }
//    }
//}

//using (var scope = app.Services.CreateScope())
//{
//	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

//    string email = "miclemarian5@gmail.com";
//    string password = "Test1234!";

//    if(await userManager.FindByEmailAsync(email) == null)
//    {
//        var user = new AppUser();
//        user.UserName = email;
//        user.Email = email;
//        user.Address = "New York";
        
//        user.NameOnCard = "Marik Micle";
//        user.CardNumber = "1234 5678 9123 4567";
//        user.ExpMonth = "01";
//        user.ExpYear = "23";
//		user.CVV = "123";


//		await userManager.CreateAsync(user,password);

//        await userManager.AddToRoleAsync(user, "Admin");
//    }
//}

app.Run();


void ConfigureMapster()
{
	TypeAdapterConfig<BranchVM, Branch>
		.NewConfig()
		.Map(dest => dest.ImageUrl, src => src.Image);
}


