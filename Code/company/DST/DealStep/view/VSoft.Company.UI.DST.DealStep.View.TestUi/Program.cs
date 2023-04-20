using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.DST.DealStep.View.Module;
using VSoft.Company.UI.DST.DealStep.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterDealStepFrontsModule();
});

