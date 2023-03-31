using Blazored.Toast;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VegunSoft.Framework.Api.DtoClient.Token.Provider.Services;
using VSoft.Company.TEA.Team.Client.Models;
using VSoft.Company.TEA.Team.Client.Provider.Services;
using VSoft.Company.TEA.Team.Client.Services;
using VSoft.Company.UI.TEA.Team.Business.Service.Provider.Services;
using VSoft.Company.UI.TEA.Team.Business.Service.Services;
using VSoft.Company.UI.TEA.Team.View.Main.Code.Pages;
using VSoft.Company.UI.TEA.Team.View.Main.Code.Provider.Pages;
using VSoft.Company.UI.TEA.Team.View.TestUi;

var JSonFileConfig = "appsettings.json";
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddTransient<IPageCreateServices, PageCreateServices>();
builder.Services.AddTransient<IPageTableServices, PageTableServices>();
builder.Services.AddBlazoredToast();

builder.Services.AddSingleton<MTeamClient>();
builder.Services.AddSingleton(new TokenService().Init(string.Empty));
builder.Services.AddSingleton(new ConfigurationBuilder().AddJsonFile(JSonFileConfig, optional: true, reloadOnChange: true).Build());

builder.Services.AddTransient<ITeamBusiness, TeamBusiness>();
builder.Services.AddTransient<ITeamClient, TeamClient>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
