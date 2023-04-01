using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VegunSoft.Framework.Api.DtoClient.Token.Provider.Services;
using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.TEA.Team.View.Module;
using VSoft.Company.UI.TEA.Team.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterTeamFrontsModule();
});

