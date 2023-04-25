using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.DQU.DealQuotation.Business.Service.Services;
using VSoft.Company.UI.DQU.DealQuotation.Data.DVO.Data;
using VSoft.Company.UI.DQU.DealQuotation.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DQU.DealQuotation.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : PageBase, IPageCreateServices
    {
        protected IDealQuotationBusiness BusinessService { get; set; }

        public PageCreateServices(IDealQuotationBusiness service)
        {
            BusinessService = service;
        }

        public async Task CreateDealQuotations(string name, string description)
        {
            Messages?.Clear();
            if (string.IsNullOrEmpty(name))
            {
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Tên nhóm không được để trống" });
                return;
            }
            var teamDvo = new DealQuotationDvo { /*Name = name, Description = description */};
            var rs = await BusinessService.CreateAsync(teamDvo);
            if (rs.IsSuccessed)
                Messages?.Add(new MMessage() { Type = EMessageType.Success, Message = $"Tạo nhóm \"{rs.ResultObj}\" thành công!" });
            else
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể tạo nhóm \"{name}\"! {rs.Message}" });
        }
    }
}
