using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.PRO.Product.Client.Models;
using VSoft.Company.PRO.Product.Client.Provider.Services;
using VSoft.Company.PRO.Product.Client.Services;
using VSoft.Company.UI.PRO.Product.Business.Service.Provider.Services;
using VSoft.Company.UI.PRO.Product.Business.Service.Services;
using VSoft.Company.UI.PRO.Product.View.Main.Code.Pages;
using VSoft.Company.UI.PRO.Product.View.Main.Code.Provider.Pages;

namespace VSoft.Company.UI.PRO.Product.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterProductFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MProductClient>();


        services.AddTransient<IPageCreateServices, PageCreateServices>();
        services.AddTransient<IPageTableServices, PageTableServices>();

        services.AddTransient<IProductBusiness, ProductBusiness>();
        services.AddTransient<IProductClient, ProductClient>();
    }
}

