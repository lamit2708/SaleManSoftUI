using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
//using VSoft.Company.UI.DST.DealStep.Business.Service.Services;
//using VSoft.Company.UI.DST.DealStep.Data.DVO.Data;
//using VSoft.Company.UI.DST.DealStep.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DST.DealStep.View.Main.Code.Provider.Pages
{
    public class PageUpdateServices : PageBase//, IPageUpdateServices
    {
        //protected IDealStepBusiness BusinessService { get; set; }
        //public DealStepDvo? DealStep { get; private set; }
        //public PageUpdateServices(IDealStepBusiness service)
        //{
        //    BusinessService = service;
        //}
        //public async Task OnInitializedAsync(string teamId)
        //{
        //    var pagingRs = await BusinessService.GetDealStep(teamId);
        //    if (pagingRs.IsSuccessed)
        //    {
        //        var data = pagingRs.ResultObj;
        //        DealStep = data;
        //    }
        //    else
        //        Messages.Add(new MMessage() { Type = EMessageType.Error, Message = pagingRs.Message });
        //}

        //public async Task OnUpdateDealStep(DealStepDvo userDvo)
        //{
        //    ClearAllMessage();
        //    if (!string.IsNullOrEmpty(userDvo.DealStepname))
        //    {
        //        var pagingRs = await BusinessService.UpdateDealStep(userDvo);
        //        if (pagingRs.IsSuccessed)
        //        {
        //            var data = pagingRs.ResultObj;
        //            Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Cập nhật DealStep {data} thành công!" });
        //        }
        //        else
        //            Messages.Add(new MMessage() { Type = EMessageType.Error, Message = pagingRs.Message });
        //    }
        //}

        //protected void ClearAllMessage()
        //{
        //    Messages?.Clear();
        //}
    }
}
