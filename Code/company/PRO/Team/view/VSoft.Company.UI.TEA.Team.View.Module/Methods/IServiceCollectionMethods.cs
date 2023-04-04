using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.PRO.Team.Client.Models;
using VSoft.Company.PRO.Team.Client.Provider.Services;
using VSoft.Company.PRO.Team.Client.Services;
using VSoft.Company.UI.PRO.Team.Business.Service.Provider.Services;
using VSoft.Company.UI.PRO.Team.Business.Service.Services;
using VSoft.Company.UI.PRO.Team.View.Main.Code.Pages;
using VSoft.Company.UI.PRO.Team.View.Main.Code.Provider.Pages;

namespace VSoft.Company.UI.PRO.Team.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterTeamFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MTeamClient>();


        services.AddTransient<IPageCreateServices, PageCreateServices>();
        services.AddTransient<IPageTableServices, PageTableServices>();

        services.AddTransient<ITeamBusiness, TeamBusiness>();
        services.AddTransient<ITeamClient, TeamClient>();
    }
}

