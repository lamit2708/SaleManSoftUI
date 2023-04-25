using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.UCU.UserCustomer.Client.Models;
using VSoft.Company.UCU.UserCustomer.Client.Provider.Services;
using VSoft.Company.UCU.UserCustomer.Client.Services;
using VSoft.Company.UI.UCU.UserCustomer.Business.Service.Provider.Services;
using VSoft.Company.UI.UCU.UserCustomer.Business.Service.Services;
using VSoft.Company.UI.UCU.UserCustomer.View.Main.Code.Provider.Pages;
using VSoft.Company.UI.UCU.UserCustomer.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.UCU.UserCustomer.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterUserCustomerFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MUserCustomerClient>();
        //services.AddSingleton<MVUserCustomerTagClient>();

        services.AddTransient<IPageCreateServices, PageCreateServices>();
        services.AddTransient<IPageTableServices, PageTableServices>();
        services.AddTransient<IPageUpdateServices, PageUpdateServices>();
        services.AddTransient<IUserCustomerBusiness, UserCustomerBusiness>();
        services.AddTransient<IUserCustomerClient, UserCustomerClient>();
    }
}

