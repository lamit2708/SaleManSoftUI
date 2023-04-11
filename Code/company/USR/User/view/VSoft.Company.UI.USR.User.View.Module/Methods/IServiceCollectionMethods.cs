using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.USR.User.Client.Models;
using VSoft.Company.USR.User.Client.Provider.Services;
using VSoft.Company.USR.User.Client.Services;
using VSoft.Company.UI.USR.User.Business.Service.Provider.Services;
using VSoft.Company.UI.USR.User.Business.Service.Services;
using VSoft.Company.UI.USR.User.View.Main.Code.Provider.Pages;
using VSoft.Company.UI.USR.User.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.USR.User.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterUserFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MUserClient>();


        services.AddTransient<IPageCreateServices, PageCreateServices>();
        services.AddTransient<IPageTableServices, PageTableServices>();
        services.AddTransient<IPageUpdateServices, PageUpdateServices>();

        services.AddTransient<IUserBusiness, UserBusiness>();
        services.AddTransient<IUserClient, UserClient>();
    }
}

