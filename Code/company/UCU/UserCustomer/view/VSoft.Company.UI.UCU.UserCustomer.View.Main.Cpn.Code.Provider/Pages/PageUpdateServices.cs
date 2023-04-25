using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.UCU.UserCustomer.Business.Service.Services;
using VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Data;
using VSoft.Company.UI.UCU.UserCustomer.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.UCU.UserCustomer.View.Main.Code.Provider.Pages
{
    public class PageUpdateServices : PageBase, IPageUpdateServices
    {
        protected IUserCustomerBusiness BusinessService { get; set; }
        public UserCustomerDvo? UserCustomer { get; private set; }
        public PageUpdateServices(IUserCustomerBusiness service)
        {
            BusinessService = service;
        }
        public async Task OnInitializedAsync(string? teamId)
        {
            var id = Convert.ToInt32(teamId ?? "0");
            var pagingRs = await BusinessService.GetUserCustomer(id);
            if (pagingRs.IsSuccessed)
            {
                var data = pagingRs.ResultObj;
                UserCustomer = data;
            }
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = pagingRs.Message });
        }

        public async Task OnUpdateUserCustomer(UserCustomerDvo dealDvo)
        {
            ClearAllMessage();
            if (dealDvo.Id != 0)
            {
                var pagingRs = await BusinessService.UpdateUserCustomer(dealDvo);
                if (pagingRs.IsSuccessed)
                {
                    var data = pagingRs.ResultObj;
                    Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Cập nhật gán khách hàng {data} thành công!" });
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
