using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.UCU.UserCustomer.View.Module;
using VSoft.Company.UI.UCU.UserCustomer.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterUserCustomerFrontsModule();
});

