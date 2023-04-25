using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.DQU.DealQuotation.Data.DVO.Data;

namespace VSoft.Company.UI.DQU.DealQuotation.Business.Service.Services
{
    public interface IDealQuotationBusiness
    {
        Task<MDvoResult<string>> CreateAsync(DealQuotationDvo teamDvo);

        //Task<MDvoResult<PagedList<DealQuotationDvo>>> GetTableDealQuotation(string keyWord, PagingParameters pageParameter);

        Task<MDvoResult<string>> DeleteDealQuotation(int id);

        Task<MDvoResult<DealQuotationDvo>> GetDealQuotation(string id);

        Task<MDvoResult<string>> UpdateDealQuotation(DealQuotationDvo team);  
    }
}
