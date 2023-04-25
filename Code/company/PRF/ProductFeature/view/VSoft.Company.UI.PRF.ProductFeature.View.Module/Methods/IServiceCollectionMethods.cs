using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.PRF.ProductFeature.Client.Models;
using VSoft.Company.PRF.ProductFeature.Client.Provider.Services;
using VSoft.Company.PRF.ProductFeature.Client.Services;
using VSoft.Company.UI.PRF.ProductFeature.Business.Service.Provider.Services;
using VSoft.Company.UI.PRF.ProductFeature.Business.Service.Services;
using VSoft.Company.UI.PRF.ProductFeature.View.Main.Code.Provider.Pages;
using VSoft.Company.UI.PRF.ProductFeature.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.PRF.ProductFeature.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterProductFeatureFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MProductFeatureClient>();


        services.AddTransient<IPageCreateServices, PageCreateServices>();
        services.AddTransient<IPageTableServices, PageTableServices>();
        services.AddTransient<IPageUpdateServices, PageUpdateServices>();

        services.AddTransient<IProductFeatureBusiness, ProductFeatureBusiness>();
        services.AddTransient<IProductFeatureClient, ProductFeatureClient>();
    }
}

