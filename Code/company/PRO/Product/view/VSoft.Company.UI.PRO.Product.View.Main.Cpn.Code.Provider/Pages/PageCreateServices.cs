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

        public async Task CreateProducts(string name, string description, double price, int quantity, int categoryId)
        {
            Messages?.Clear();
            if (string.IsNullOrEmpty(name))
            {
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Tên sản phẩm không được để trống" });
                return;
            }
            categoryId = categoryId == 0 ? 1 : categoryId; 
            var teamDvo = new ProductDvo { Name = name, Description = description, Price = price, Quantity = quantity, CategoryId = categoryId };
            var rs = await BusinessService.CreateAsync(teamDvo);
            if (rs.IsSuccessed)
                Messages?.Add(new MMessage() { Type = EMessageType.Success, Message = $"Tạo sản phẩm \"{rs.ResultObj}\" thành công!" });
            else
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể tạo sản phẩm \"{name}\"! {rs.Message}" });
        }
    }
}
