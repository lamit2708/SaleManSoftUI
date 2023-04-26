using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
//using VSoft.Company.UI.DST.DealStep.Business.Service.Services;
//using VSoft.Company.UI.DST.DealStep.Data.DVO.Data;
//using VSoft.Company.UI.DST.DealStep.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DST.DealStep.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : PageBase//, IPageCreateServices
    {
        //protected IDealStepBusiness BusinessService { get; set; }

        //public PageCreateServices(IDealStepBusiness service)
        //{
        //    BusinessService = service;
        //}

        //public async Task CreateDealSteps(DealStepDvo userDvo)
        //{
        //    Messages?.Clear();
        //    if (string.IsNullOrEmpty(userDvo.DealStepname) || string.IsNullOrEmpty(userDvo.Password))
        //    {
        //        Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Tên DealStep / Password không được để trống" });
        //        return;
        //    }
        //    var rs = await BusinessService.CreateAsync(userDvo);
        //    if (rs.IsSuccessed)
        //        Messages?.Add(new MMessage() { Type = EMessageType.Success, Message = $"Tạo DealStep \"{rs.ResultObj}\" thành công!" });
        //    else
        //        Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể tạo DealStep \"{userDvo.DealStepname}\"! {rs.Message}" });
        //}
    }
}
