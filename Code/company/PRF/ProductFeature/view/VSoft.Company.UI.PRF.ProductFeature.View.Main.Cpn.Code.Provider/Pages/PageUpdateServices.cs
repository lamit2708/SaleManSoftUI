using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.PRF.ProductFeature.Business.Service.Services;
using VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Data;
using VSoft.Company.UI.PRF.ProductFeature.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.PRF.ProductFeature.View.Main.Code.Provider.Pages
{
    public class PageUpdateServices : PageBase, IPageUpdateServices
    {
        protected IProductFeatureBusiness BusinessService { get; set; }
        public ProductFeatureDvo? ProductFeature { get; private set; }
        public PageUpdateServices(IProductFeatureBusiness service)
        {
            BusinessService = service;
        }
        public async Task OnInitializedAsync(string productfeatureId)
        {
            int id= Int32.Parse(productfeatureId);
            var pagingRs = await BusinessService.GetProductFeature(id);
            if (pagingRs.IsSuccessed)
            {
                var data = pagingRs.ResultObj;
                ProductFeature = data;
            }
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = pagingRs.Message });
        }

        public async Task OnUpdateProductFeature(ProductFeatureDvo productfeature)
        {
            ClearAllMessage();
            if (productfeature.Id != 0)
            {
                var pagingRs = await BusinessService.UpdateProductFeature(productfeature);
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
