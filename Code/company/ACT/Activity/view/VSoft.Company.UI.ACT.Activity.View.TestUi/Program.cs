using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.ACT.Activity.View.Module;
using VSoft.Company.UI.ACT.Activity.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterActivityFrontsModule();
});

