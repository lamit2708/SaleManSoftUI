using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.DEA.Deal.Client.Models;
using VSoft.Company.DEA.Deal.Client.Provider.Services;
using VSoft.Company.DEA.Deal.Client.Services;
using VSoft.Company.UI.DEA.Deal.Business.Service.Provider.Services;
using VSoft.Company.UI.DEA.Deal.Business.Service.Services;
using VSoft.Company.UI.DEA.Deal.View.Main.Code.Provider.Pages;
using VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.VDT.VDealTag.Client.Models;
using VSoft.Company.VDT.VDealTag.Client.Provider.Services;
using VSoft.Company.VDT.VDealTag.Client.Services;

namespace VSoft.Company.UI.DEA.Deal.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterDealFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MDealClient>();
        services.AddSingleton<MVDealTagClient>();

        services.AddTransient<IPageCreateServices, PageCreateServices>();
        services.AddTransient<IPageTableServices, PageTableServices>();
        services.AddTransient<IPageUpdateServices, PageUpdateServices>();
        services.AddTransient<IPageDealTagServices, PageDealTagServices>();

        services.AddTransient<IDealBusiness, DealBusiness>();
        services.AddTransient<IDealClient, DealClient>();
        services.AddTransient<IVDealTagClient, VDealTagClient>();
    }
}

