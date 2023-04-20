using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.DST.DealStep.Client.Models;
using VSoft.Company.DST.DealStep.Client.Provider.Services;
using VSoft.Company.DST.DealStep.Client.Services;

namespace VSoft.Company.UI.DST.DealStep.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterDealStepFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MDealStepClient>();


        //services.AddTransient<IPageCreateServices, PageCreateServices>();
        //services.AddTransient<IPageTableServices, PageTableServices>();
        //services.AddTransient<IPageUpdateServices, PageUpdateServices>();

        //services.AddTransient<IDealStepBusiness, DealStepBusiness>();
        services.AddTransient<IDealStepClient, DealStepClient>();
    }
}

