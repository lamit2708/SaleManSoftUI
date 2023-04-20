using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.PRC.ProductCategory.Business.Service.Services;
using VSoft.Company.UI.PRC.ProductCategory.Data.DVO.Data;
using VSoft.Company.UI.PRC.ProductCategory.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.PRC.ProductCategory.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : PageBase, IPageCreateServices
    {
        protected IProductCategoryBusiness BusinessService { get; set; }

        public PageCreateServices(IProductCategoryBusiness service)
        {
            BusinessService = service;
        }

        public async Task CreateProductCategorys(string name, string description)
        {
            Messages?.Clear();
            if (string.IsNullOrEmpty(name))
            {
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Tên danh mục sản phẩm không được để trống" });
                return;
            }
            var teamDvo = new ProductCategoryDvo { Name = name };
            var rs = await BusinessService.CreateAsync(teamDvo);
            if (rs.IsSuccessed)
                Messages?.Add(new MMessage() { Type = EMessageType.Success, Message = $"Tạo danh mục  \"{rs.ResultObj}\" thành công!" });
            else
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể tạo danh mục \"{name}\"! {rs.Message}" });
        }
    }
}
