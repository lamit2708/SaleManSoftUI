using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.ACT.Activity.Business.Service.Services;
using VSoft.Company.UI.ACT.Activity.Data.DVO.Data;
using VSoft.Company.UI.ACT.Activity.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.ACT.Activity.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : PageBase, IPageCreateServices
    {
        protected IActivityBusiness BusinessService { get; set; }

        public PageCreateServices(IActivityBusiness service)
        {
            BusinessService = service;
        }

        public async Task CreateActivitys(ActivityDvo activityDvo)
        {
            Messages?.Clear();
            if (string.IsNullOrEmpty(activityDvo.Name))
            {
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Tên Activity không được để trống" });
                return;
            }
            var rs = await BusinessService.CreateAsync(activityDvo);
            if (rs.IsSuccessed)
                Messages?.Add(new MMessage() { Type = EMessageType.Success, Message = $"Tạo Activity \"{rs.ResultObj}\" thành công!" });
            else
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể tạo Activity \"{activityDvo.Name}\"! {rs.Message}" });
        }
    }
}
