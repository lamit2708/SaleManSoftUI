using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VegunSoft.Framework.Api.DtoClient.Token.Provider.Services;
using VSoft.Company.UI.TEA.Team.View.Module;
using VSoft.Company.UI.TEA.Team.View.TestUi;

var JSonFileConfig = "appsettings.json";
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddBlazoredToast();
builder.Services.AddSingleton(new TokenService().Init(string.Empty));
builder.Services.AddSingleton(new ConfigurationBuilder().AddJsonFile(JSonFileConfig, optional: true, reloadOnChange: true).Build());


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.RegisterTeamFrontsModule();

await builder.Build().RunAsync();
