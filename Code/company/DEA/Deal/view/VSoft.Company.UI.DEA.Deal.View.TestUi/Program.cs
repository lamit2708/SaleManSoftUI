using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.DEA.Deal.View.Module;
using VSoft.Company.UI.DEA.Deal.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterDealFrontsModule();
});

