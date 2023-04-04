using VSoft.Company.UI.PRO.Product.Business.Service.Services;
using VSoft.Company.UI.PRO.Product.View.Main.Code.Pages;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;

namespace VSoft.Company.UI.PRO.Product.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : IPageCreateServices
    {
        protected IProductBusiness BusinessService { get; set; }
        public List<string> PageMessage { get; private set; } = new List<string>();
        public bool IsSuccess { get; private set; }

        public PageCreateServices(IProductBusiness service)
        {
            BusinessService = service;
        }

        public async Task CreateProducts(string name, string description)
        {
            PageMessage?.Clear();
            if (string.IsNullOrEmpty(name))
            {
                IsSuccess = false;
                PageMessage[0] = "Tên Product không được để trống";
                return;
            }
            var teamDvo = new ProductDvo { Name = name, Description = description };
            var rs = await BusinessService.CreateAsync(teamDvo);
            if (rs.IsSuccessed)
                PageMessage.Add($"Tạo Product \"{rs.ResultObj}\" thành công!");
            else
                PageMessage.Add($"Không thể tạo Product \"{name}\"! {rs.Message}");
            IsSuccess = rs.IsSuccessed;
        }
    }
}
