using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.CTM.Customer.View.Module;
using VSoft.Company.UI.CTM.Customer.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterCustomerFrontsModule();
});

