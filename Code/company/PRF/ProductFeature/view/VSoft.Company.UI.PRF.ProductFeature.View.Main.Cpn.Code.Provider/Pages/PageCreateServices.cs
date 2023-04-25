using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.PRF.ProductFeature.Business.Service.Services;
using VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Data;
using VSoft.Company.UI.PRF.ProductFeature.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.PRF.ProductFeature.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : PageBase, IPageCreateServices
    {
        protected IProductFeatureBusiness BusinessService { get; set; }

        public PageCreateServices(IProductFeatureBusiness service)
        {
            BusinessService = service;
        }

        public async Task CreateProductFeatures(ProductFeatureDvo productfeature)
        {

            Messages?.Clear();
            if (string.IsNullOrEmpty(productfeature.Name))
            {
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Tên khách hàng không được để trống" });
                return;
            }
            // var teamDvo = new ProductFeatureDvo { Name = productfeature.Name, Phone  = productfeature. };
            var rs = await BusinessService.CreateAsync(productfeature);
            if (rs.IsSuccessed)
                Messages?.Add(new MMessage() { Type = EMessageType.Success, Message = $"Tạo khách hàng \"{rs.ResultObj}\" thành công!" });
            else
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể tạo khách hàng \"{productfeature.Name}\"! {rs.Message}" });
        }
    }
}
