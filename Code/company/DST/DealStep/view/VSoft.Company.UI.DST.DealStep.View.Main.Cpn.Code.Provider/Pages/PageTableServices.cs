using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VegunSoft.Framework.Paging.Provider.Request;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
//using VSoft.Company.UI.DST.DealStep.Business.Service.Services;
//using VSoft.Company.UI.DST.DealStep.Data.DVO.Data;
using VSoft.Company.UI.DST.DealStep.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DST.DealStep.View.Main.Code.Provider.Pages
{
    public class PageTableServices : PageTableBase, IPageTableServices
    {
        //protected IDealStepBusiness BusinessService { get; set; }
        //public List<DealStepDvo>? DealSteps { get; private set; }

        //public PageTableServices(IDealStepBusiness service)
        //{
        //    BusinessService = service;
        //}

        //public async Task OnInitializedAsync()
        //{
        //    await GetDealSteps();
        //}

        //public async Task OnSearch(string keySearch)
        //{
        //    ClearAllMessage();
        //    KeySearch = keySearch;
        //    PageParam = new PagingParameters();
        //    await GetDealSteps();
        //}

        //public async Task OnDeleteTask(int deleteId)
        //{
        //    ClearAllMessage();
        //    var rs = await BusinessService.DeleteDealStep(deleteId);
        //    if (rs.IsSuccessed) 
        //        Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Xóa DealStep \"{rs.ResultObj}\" thành công!" });
        //    else
        //        Messages.Add(new MMessage() { Type = EMessageType.Error, Message = $"Xóa DealStep \"{rs.ResultObj}\" thất bại!" });
        //    await GetDealSteps();
        //}

        //public async Task OnPageSelect(int page)
        //{
        //    ClearAllMessage();
        //    PageParam.PageNumber = page;
        //    await GetDealSteps();
        //}

        //protected async Task GetDealSteps()
        //{
        //    var pagingRs = await BusinessService.GetTableDealStep(string.IsNullOrEmpty(KeySearch) ? string.Empty : KeySearch, PageParam);
        //    if (pagingRs.IsSuccessed) 
        //    {
        //        var data = pagingRs.ResultObj;
        //        DealSteps = data.Items;
        //        MetaData = data.MetaData;
        //    }
        //    else
        //        Messages.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể load trang \"{PageParam.PageNumber}\" với từ khóa \"{KeySearch}\"" });
        //}

        //protected void ClearAllMessage()
        //{
        //    Messages?.Clear();
        //}
    }
}
