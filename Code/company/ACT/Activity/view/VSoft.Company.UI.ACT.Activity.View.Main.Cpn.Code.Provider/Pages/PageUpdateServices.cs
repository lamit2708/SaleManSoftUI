using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.ACT.Activity.Business.Service.Services;
using VSoft.Company.UI.ACT.Activity.Data.DVO.Data;
using VSoft.Company.UI.ACT.Activity.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.ACT.Activity.View.Main.Code.Provider.Pages
{
    public class PageUpdateServices : PageBase, IPageUpdateServices
    {
        protected IActivityBusiness BusinessService { get; set; }
        public ActivityDvo? Activity { get; private set; }
        public PageUpdateServices(IActivityBusiness service)
        {
            BusinessService = service;
        }
        public async Task OnInitializedAsync(string teamId)
        {
            var pagingRs = await BusinessService.GetActivity(teamId);
            if (pagingRs.IsSuccessed)
            {
                var data = pagingRs.ResultObj;
                Activity = data;
            }
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = pagingRs.Message });
        }

        public async Task OnUpdateActivity(ActivityDvo activityDvo)
        {
            ClearAllMessage();
            if (activityDvo.Id != 0)
            {
                var pagingRs = await BusinessService.UpdateActivity(activityDvo);
                if (pagingRs.IsSuccessed)
                {
                    var data = pagingRs.ResultObj;
                    Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Cập nhật sự kiện {data} thành công!" });
                }
                else
                    Messages.Add(new MMessage() { Type = EMessageType.Error, Message = pagingRs.Message });
            }
        }

        protected void ClearAllMessage()
        {
            Messages?.Clear();
        }
    }
}
