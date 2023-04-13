using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.TEA.Team.View.Module;
using VSoft.Company.UI.TEA.Team.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterTeamFrontsModule();
});

