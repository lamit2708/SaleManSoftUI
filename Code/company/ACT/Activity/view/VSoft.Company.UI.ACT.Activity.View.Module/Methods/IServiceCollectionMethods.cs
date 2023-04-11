using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.ACT.Activity.Client.Models;
using VSoft.Company.ACT.Activity.Client.Provider.Services;
using VSoft.Company.ACT.Activity.Client.Services;
using VSoft.Company.UI.ACT.Activity.Business.Service.Provider.Services;
using VSoft.Company.UI.ACT.Activity.Business.Service.Services;
using VSoft.Company.UI.ACT.Activity.View.Main.Code.Provider.Pages;
using VSoft.Company.UI.ACT.Activity.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.ACT.Activity.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterActivityFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MActivityClient>();


        services.AddTransient<IPageCreateServices, PageCreateServices>();
        services.AddTransient<IPageTableServices, PageTableServices>();
        services.AddTransient<IPageUpdateServices, PageUpdateServices>();

        services.AddTransient<IActivityBusiness, ActivityBusiness>();
        services.AddTransient<IActivityClient, ActivityClient>();
    }
}

