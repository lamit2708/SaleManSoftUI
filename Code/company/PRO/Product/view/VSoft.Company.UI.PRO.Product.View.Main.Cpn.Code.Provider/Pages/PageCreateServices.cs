using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.PRO.Product.Business.Service.Services;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;
using VSoft.Company.UI.PRO.Product.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.PRO.Product.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : PageBase, IPageCreateServices
    {
        protected IProductBusiness BusinessService { get; set; }

        public PageCreateServices(IProductBusiness service)
        {
            BusinessService = service;
        }

        public async Task CreateProducts(string name, string description)
        {
            Messages?.Clear();
            if (string.IsNullOrEmpty(name))
            {
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Tên Product không được để trống" });
                return;
            }
            var teamDvo = new ProductDvo { Name = name, Description = description };
            var rs = await BusinessService.CreateAsync(teamDvo);
            if (rs.IsSuccessed)
                Messages?.Add(new MMessage() { Type = EMessageType.Success, Message = $"Tạo Product \"{rs.ResultObj}\" thành công!" });
            else
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể tạo Product \"{name}\"! {rs.Message}" });
        }
    }
}
