using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.DQU.DealQuotation.Client.Models;
using VSoft.Company.DQU.DealQuotation.Client.Provider.Services;
using VSoft.Company.DQU.DealQuotation.Client.Services;
using VSoft.Company.UI.DQU.DealQuotation.Business.Service.Provider.Services;
using VSoft.Company.UI.DQU.DealQuotation.Business.Service.Services;
using VSoft.Company.UI.DQU.DealQuotation.View.Main.Code.Provider.Pages;
using VSoft.Company.UI.DQU.DealQuotation.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DQU.DealQuotation.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterDealQuotationFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MDealQuotationClient>();


        services.AddTransient<IPageCreateServices, PageCreateServices>();

        services.AddTransient<IDealQuotationBusiness, DealQuotationBusiness>();
        services.AddTransient<IDealQuotationClient, DealQuotationClient>();
    }
}

