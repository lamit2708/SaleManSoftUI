using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.UCU.UserCustomer.Business.Service.Services;
using VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Data;
using VSoft.Company.UI.UCU.UserCustomer.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.UCU.UserCustomer.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : PageBase, IPageCreateServices
    {
        protected IUserCustomerBusiness BusinessService { get; set; }

        public PageCreateServices(IUserCustomerBusiness service)
        {
            BusinessService = service;
        }

        public async Task CreateUserCustomers(UserCustomerDvo dealDvo)
        {
            Messages?.Clear();
            if (dealDvo?.CustomerId==null || dealDvo.CustomerId==0)
            {
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Khách hàng không được để trống" });
                return;
            }
			if (dealDvo?.UserId == null || dealDvo.UserId == 0)
			{
				Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Nhân viên không được để trống" });
				return;
			}
			var rs = await BusinessService.CreateAsync(dealDvo);
            if (rs.IsSuccessed)
                Messages?.Add(new MMessage() { Type = EMessageType.Success, Message = $"Tạo gán khách hàng \"{rs.ResultObj}\" thành công!" });
            else
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể tạo gán khách hàng \"{dealDvo.CustomerId}\"! {rs.Message}" });
        }
    }
}
