using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.PRO.Team.View.Module;
using VSoft.Company.UI.PRO.Team.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterTeamFrontsModule();
});

