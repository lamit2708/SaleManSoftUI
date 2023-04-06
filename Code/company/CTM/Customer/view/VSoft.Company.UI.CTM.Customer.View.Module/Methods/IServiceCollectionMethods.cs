using Microsoft.Extensions.DependencyInjection;
using VSoft.Company.CTM.Customer.Client.Models;
using VSoft.Company.CTM.Customer.Client.Provider.Services;
using VSoft.Company.CTM.Customer.Client.Services;
using VSoft.Company.UI.CTM.Customer.Business.Service.Provider.Services;
using VSoft.Company.UI.CTM.Customer.Business.Service.Services;
using VSoft.Company.UI.CTM.Customer.View.Main.Code.Provider.Pages;
using VSoft.Company.UI.CTM.Customer.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.CTM.Customer.View.Module;
public static class IServiceCollectionMethods
{
    public static void RegisterCustomerFrontsModule(this IServiceCollection services)
    {
        services.AddSingleton<MCustomerClient>();


        services.AddTransient<IPageCreateServices, PageCreateServices>();
        services.AddTransient<IPageTableServices, PageTableServices>();
        services.AddTransient<IPageUpdateServices, PageUpdateServices>();

        services.AddTransient<ICustomerBusiness, CustomerBusiness>();
        services.AddTransient<ICustomerClient, CustomerClient>();
    }
}

