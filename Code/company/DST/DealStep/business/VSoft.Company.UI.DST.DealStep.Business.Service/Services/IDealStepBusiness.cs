using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.DST.DealStep.Data.DVO.Data;

namespace VSoft.Company.UI.DST.DealStep.Business.Service.Services
{
    public interface IDealStepBusiness
    {
        Task<MDvoResult<string>> CreateAsync(DealStepDvo teamDvo);

        //Task<MDvoResult<PagedList<DealStepDvo>>> GetTableDealStep(string keyWord, PagingParameters pageParameter);

        Task<MDvoResult<string>> DeleteDealStep(int id);

        Task<MDvoResult<DealStepDvo>> GetDealStep(string id);

        Task<MDvoResult<string>> UpdateDealStep(DealStepDvo team);
		Task<MDvoResult<List<KeyValuePair<int, string>>>> GetAll();
	}
}
