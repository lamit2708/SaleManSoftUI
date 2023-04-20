using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.CTM.Customer.Business.Service.Services;
using VSoft.Company.UI.CTM.Customer.Data.DVO.Data;
using VSoft.Company.UI.CTM.Customer.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.CTM.Customer.View.Main.Code.Provider.Pages
{
    public class PageUpdateServices : PageBase, IPageUpdateServices
    {
        protected ICustomerBusiness BusinessService { get; set; }
        public CustomerDvo? Customer { get; private set; }
        public PageUpdateServices(ICustomerBusiness service)
        {
            BusinessService = service;
        }
        public async Task OnInitializedAsync(string customerId)
        {
            var pagingRs = await BusinessService.GetCustomer(customerId);
            if (pagingRs.IsSuccessed)
            {
                var data = pagingRs.ResultObj;
                Customer = data;
            }
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = pagingRs.Message });
        }

        public async Task OnUpdateCustomer(CustomerDvo customer)
        {
            ClearAllMessage();
            if (customer.Id !=0)
            {
                var pagingRs = await BusinessService.UpdateCustomer(customer);
                if (pagingRs.IsSuccessed)
                {
                    var data = pagingRs.ResultObj;
                    Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Cập nhật khách hàng {data} thành công!" });
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
