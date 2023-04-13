using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.TEA.Team.Client.Models;
using VSoft.Company.TEA.Team.Client.Provider.Services;
using VSoft.Company.TEA.Team.Client.Services;
using VSoft.Company.UI.TEA.Team.Business.Service.Provider.Services;
using VSoft.Company.UI.TEA.Team.Business.Service.Services;
using VSoft.Company.UI.TEA.Team.View.Main.Code.Provider.Pages;
using VSoft.Company.UI.TEA.Team.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.TEA.Team.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterTeamFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MTeamClient>();


        services.AddTransient<IPageCreateServices, PageCreateServices>();
        services.AddTransient<IPageTableServices, PageTableServices>();
        services.AddTransient<IPageUpdateServices, PageUpdateServices>();

        services.AddTransient<ITeamBusiness, TeamBusiness>();
        services.AddTransient<ITeamClient, TeamClient>();
    }
}

