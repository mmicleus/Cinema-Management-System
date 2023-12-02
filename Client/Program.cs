using BlazorCinemaMS.Client;
using BlazorCinemaMS.Client.Services;
using BlazorCinemaMS.Client.Services.BranchesService;
using BlazorCinemaMS.Client.Services.MoviesService;
using BlazorCinemaMS.Client.Services.SessionsService;
using BlazorCinemaMS.Client.Services.UtilityService;
using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


ConfigureMapster();

//Console.WriteLine(builder.HostEnvironment.BaseAddress);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<StateContainer>();

builder.Services.AddScoped<IMoviesService,MoviesService>();
builder.Services.AddScoped<IBranchesService, BranchesService>();
builder.Services.AddScoped<ISessionsService, SessionsService>();
builder.Services.AddScoped<IUtilityService, UtilityService>();


await builder.Build().RunAsync();


void ConfigureMapster()
{
	TypeAdapterConfig<BranchDTO, BranchVM>
		.NewConfig()
		.Map(dest => dest.Image, src => src.ImageUrl);
}

