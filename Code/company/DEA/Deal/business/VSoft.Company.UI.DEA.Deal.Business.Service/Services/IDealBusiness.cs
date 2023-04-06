using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;

namespace VSoft.Company.UI.DEA.Deal.Business.Service.Services
{
    public interface IDealBusiness
    {
        Task<MDvoResult<string>> CreateAsync(DealDvo teamDvo);

        Task<MDvoResult<PagedList<DealDvo>>> GetTableDeal(string keyWord, PagingParameters pageParameter);

        Task<MDvoResult<string>> DeleteDeal(long id);

        Task<MDvoResult<DealDvo>> GetDeal(string id);

        Task<MDvoResult<string>> UpdateDeal(DealDvo team);  
    }
}
