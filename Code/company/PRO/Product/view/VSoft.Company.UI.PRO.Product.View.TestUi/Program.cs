using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.PRO.Product.View.Module;
using VSoft.Company.UI.PRO.Product.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterProductFrontsModule();
});

