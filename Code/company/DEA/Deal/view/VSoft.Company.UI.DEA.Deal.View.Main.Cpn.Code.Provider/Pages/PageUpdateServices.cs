using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.DEA.Deal.Business.Service.Services;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;
using VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Code.Provider.Pages
{
    public class PageUpdateServices : PageBase, IPageUpdateServices
    {
        protected IDealBusiness BusinessService { get; set; }
        public DealDvo? Deal { get; private set; }
        public PageUpdateServices(IDealBusiness service)
        {
            BusinessService = service;
        }
        public async Task OnInitializedAsync(string teamId)
        {
            var pagingRs = await BusinessService.GetDeal(teamId);
            if (pagingRs.IsSuccessed)
            {
                var data = pagingRs.ResultObj;
                Deal = data;
            }
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = pagingRs.Message });
        }

        public async Task OnUpdateDeal(string teamId, string name, string description)
        {
            ClearAllMessage();
            var id = Int32.TryParse(teamId, out var idInt) ? idInt : 0;
            if (id != 0)
            {
                var pagingRs = await BusinessService.UpdateDeal(new DealDvo()
                {
                    Id = id,
                    Name = name,
                    Description = description
                });
                if (pagingRs.IsSuccessed)
                {
                    var data = pagingRs.ResultObj;
                    Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Cập nhật Deal {data} thành công!" });
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
