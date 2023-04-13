using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.PRC.ProductCategory.View.Module;
using VSoft.Company.UI.PRC.ProductCategory.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterProductCategoryFrontsModule();
});

