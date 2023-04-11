using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.USR.User.Data.DVO.Data;

namespace VSoft.Company.UI.USR.User.Business.Service.Services
{
    public interface IUserBusiness
    {
        Task<MDvoResult<string>> CreateAsync(UserDvo teamDvo);

        Task<MDvoResult<PagedList<UserDvo>>> GetTableUser(string keyWord, PagingParameters pageParameter);

        Task<MDvoResult<string>> DeleteUser(int id);

        Task<MDvoResult<UserDvo>> GetUser(string id);

        Task<MDvoResult<string>> UpdateUser(UserDvo team);  
    }
}
