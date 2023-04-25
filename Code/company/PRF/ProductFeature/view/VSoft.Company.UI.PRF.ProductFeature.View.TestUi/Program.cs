using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.PRF.ProductFeature.View.Module;
using VSoft.Company.UI.PRF.ProductFeature.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterProductFeatureFrontsModule();
});

