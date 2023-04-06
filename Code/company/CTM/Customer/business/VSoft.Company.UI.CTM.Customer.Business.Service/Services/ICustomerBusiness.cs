using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.CTM.Customer.Data.DVO.Data;

namespace VSoft.Company.UI.CTM.Customer.Business.Service.Services
{
    public interface ICustomerBusiness
    {
        Task<MDvoResult<string>> CreateAsync(CustomerDvo teamDvo);

        Task<MDvoResult<PagedList<CustomerDvo>>> GetTableCustomer(string keyWord, PagingParameters pageParameter);

        Task<MDvoResult<string>> DeleteCustomer(int id);

        Task<MDvoResult<CustomerDvo>> GetCustomer(string id);

        Task<MDvoResult<string>> UpdateCustomer(CustomerDvo team);
    }
}
