using Main.UI.WebApp;
using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.ACT.Activity.View.Module;
using VSoft.Company.UI.DEA.Deal.View.Module;
using VSoft.Company.UI.TEA.Team.View.Module;
using VSoft.Company.UI.USR.User.View.Module;
using VSoft.Company.UI.CTM.Customer.View.Module;
using VSoft.Company.UI.PRO.Product.View.Module;
using VSoft.Company.UI.PRC.ProductCategory.View.Module;
using VSoft.Company.UI.DST.DealStep.View.Module;
using VSoft.Company.UI.UCU.UserCustomer.View.Module;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterTeamFrontsModule();
    builder.Services.RegisterActivityFrontsModule();
    builder.Services.RegisterDealFrontsModule();
    builder.Services.RegisterUserFrontsModule();
    builder.Services.RegisterCustomerFrontsModule();
    builder.Services.RegisterProductFrontsModule();
    builder.Services.RegisterProductCategoryFrontsModule();
    builder.Services.RegisterUserCustomerFrontsModule();
    builder.Services.RegisterDealStepFrontsModule();
});
