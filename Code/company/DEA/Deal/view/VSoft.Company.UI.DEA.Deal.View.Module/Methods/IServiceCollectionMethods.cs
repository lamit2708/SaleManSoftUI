using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.DEA.Deal.Client.Models;
using VSoft.Company.DEA.Deal.Client.Provider.Services;
using VSoft.Company.DEA.Deal.Client.Services;
using VSoft.Company.UI.DEA.Deal.Business.Service.Provider.Services;
using VSoft.Company.UI.DEA.Deal.Business.Service.Services;
using VSoft.Company.UI.DEA.Deal.View.Main.Code.Provider.Pages;
using VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DEA.Deal.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterDealFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MDealClient>();


        services.AddTransient<IPageCreateServices, PageCreateServices>();
        services.AddTransient<IPageTableServices, PageTableServices>();
        services.AddTransient<IPageUpdateServices, PageUpdateServices>();

        services.AddTransient<IDealBusiness, DealBusiness>();
        services.AddTransient<IDealClient, DealClient>();
    }
}

