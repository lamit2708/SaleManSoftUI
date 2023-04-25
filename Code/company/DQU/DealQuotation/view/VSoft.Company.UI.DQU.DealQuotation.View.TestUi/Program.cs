using VSoft.Common.UI.APP.Base.View.Main;
using VSoft.Company.UI.DQU.DealQuotation.View.Module;
using VSoft.Company.UI.DQU.DealQuotation.View.TestUi;

AppServices.RunApp((builder) =>
{
    builder.RootComponents.Add<App>("#app");
    builder.Services.RegisterDealQuotationFrontsModule();
});

