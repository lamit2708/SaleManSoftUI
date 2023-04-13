using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.PRC.ProductCategory.Client.Models;
using VSoft.Company.PRC.ProductCategory.Client.Provider.Services;
using VSoft.Company.PRC.ProductCategory.Client.Services;
using VSoft.Company.UI.PRC.ProductCategory.Business.Service.Provider.Services;
using VSoft.Company.UI.PRC.ProductCategory.Business.Service.Services;
using VSoft.Company.UI.PRC.ProductCategory.View.Main.Code.Provider.Pages;
using VSoft.Company.UI.PRC.ProductCategory.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.PRC.ProductCategory.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterProductCategoryFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MProductCategoryClient>();


        services.AddTransient<IPageCreateServices, PageCreateServices>();
        services.AddTransient<IPageTableServices, PageTableServices>();
        services.AddTransient<IPageUpdateServices, PageUpdateServices>();

        services.AddTransient<IProductCategoryBusiness, ProductCategoryBusiness>();
        services.AddTransient<IProductCategoryClient, ProductCategoryClient>();
    }
}

