using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.USR.User.View.Module;
using VSoft.Company.UI.USR.User.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterUserFrontsModule();
});

