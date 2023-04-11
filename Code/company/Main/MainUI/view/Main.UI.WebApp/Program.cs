using Main.UI.WebApp;
using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.TEA.Team.View.Module;

//var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.Services.RegisterTeamFrontsModule();
//builder.RootComponents.Add<HeadOutlet>("head::after");
//builder.Services.AddSingleton<IConfigurationRoot>(builder.Configuration);
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddSingleton(new TokenService().Init(string.Empty));
//await builder.Build().RunAsync();

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterTeamFrontsModule();
});
