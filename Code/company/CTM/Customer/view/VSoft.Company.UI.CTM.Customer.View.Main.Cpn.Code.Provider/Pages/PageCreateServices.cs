﻿using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.CTM.Customer.Business.Service.Services;
using VSoft.Company.UI.CTM.Customer.Data.DVO.Data;
using VSoft.Company.UI.CTM.Customer.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.CTM.Customer.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : PageBase, IPageCreateServices
    {
        protected ICustomerBusiness BusinessService { get; set; }

        public PageCreateServices(ICustomerBusiness service)
        {
            BusinessService = service;
        }

        public async Task CreateCustomers(CustomerDvo customer)
        {

            Messages?.Clear();
            if (string.IsNullOrEmpty(customer.Name))
            {
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Tên khách hàng không được để trống" });
                return;
            }
           // var teamDvo = new CustomerDvo { Name = customer.Name, Phone  = customer. };
            var rs = await BusinessService.CreateAsync(customer);
            if (rs.IsSuccessed)
                Messages?.Add(new MMessage() { Type = EMessageType.Success, Message = $"Tạo khách hàng \"{rs.ResultObj}\" thành công!" });
            else
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể tạo khách hàng \"{customer.Name}\"! {rs.Message}" });
        }
    }
}
