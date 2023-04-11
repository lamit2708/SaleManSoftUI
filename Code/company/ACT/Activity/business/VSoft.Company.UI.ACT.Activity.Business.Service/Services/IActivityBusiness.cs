using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.ACT.Activity.Data.DVO.Data;

namespace VSoft.Company.UI.ACT.Activity.Business.Service.Services
{
    public interface IActivityBusiness
    {
        Task<MDvoResult<string>> CreateAsync(ActivityDvo teamDvo);

        Task<MDvoResult<PagedList<ActivityDvo>>> GetTableActivity(string keyWord, PagingParameters pageParameter);

        Task<MDvoResult<string>> DeleteActivity(int id);

        Task<MDvoResult<ActivityDvo>> GetActivity(string id);

        Task<MDvoResult<string>> UpdateActivity(ActivityDvo team);  
    }
}
