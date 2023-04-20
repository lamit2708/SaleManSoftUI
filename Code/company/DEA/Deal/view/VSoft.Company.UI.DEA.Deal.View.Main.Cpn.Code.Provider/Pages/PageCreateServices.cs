using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.DEA.Deal.Business.Service.Services;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;
using VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : PageBase, IPageCreateServices
    {
        protected IDealBusiness BusinessService { get; set; }

        public PageCreateServices(IDealBusiness service)
        {
            BusinessService = service;
        }

        public async Task CreateDeals(DealDvo dealDvo)
        {
            Messages?.Clear();
            if (string.IsNullOrEmpty(dealDvo.Name))
            {
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Tên hợp đồng không được để trống" });
                return;
            }
            var rs = await BusinessService.CreateAsync(dealDvo);
            if (rs.IsSuccessed)
                Messages?.Add(new MMessage() { Type = EMessageType.Success, Message = $"Tạo hợp đồng \"{rs.ResultObj}\" thành công!" });
            else
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể tạo hợp đồng \"{dealDvo.Name}\"! {rs.Message}" });
        }
    }
}
