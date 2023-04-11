using Main.UI.WebApp;
using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.ACT.Activity.View.Module;
using VSoft.Company.UI.TEA.Team.View.Module;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterTeamFrontsModule();
    builder.Services.RegisterActivityFrontsModule();
});
