using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Data;

namespace VSoft.Company.UI.UCU.UserCustomer.Business.Service.Services
{
    public interface IUserCustomerBusiness
    {
        Task<MDvoResult<string>> CreateAsync(UserCustomerDvo teamDvo);

        Task<MDvoResult<PagedList<UserCustomerDvo>>> GetTableUserCustomer(string keyWord, PagingParameters pageParameter);

        Task<MDvoResult<string>> DeleteUserCustomer(int id);

        Task<MDvoResult<UserCustomerDvo>> GetUserCustomer(int id);

        Task<MDvoResult<string>> UpdateUserCustomer(UserCustomerDvo team);


      
        Task<MDvoResult<Dictionary<int, string>>> GetUser();
        Task<MDvoResult<Dictionary<int, string>>> GetTeam();
    }
}
