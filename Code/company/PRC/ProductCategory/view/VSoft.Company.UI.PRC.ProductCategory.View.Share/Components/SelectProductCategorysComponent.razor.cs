using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSoft.Company.UI.PRC.ProductCategory.Business.Service.Services;
using VSoft.Company.UI.PRC.ProductCategory.Data.DVO.Data;

namespace VSoft.Company.UI.PRC.ProductCategory.View.Share.Components
{
    public partial class SelectProductCategorysComponent
    {
        [Inject] IProductCategoryBusiness BusinessService { get; set; }

        [Parameter]
        public int SelectedItem { get; set; }

        List<ProductCategoryDvo> Data { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var result = await BusinessService.GetAll();
            if (result != null)
            {
                if (result.IsSuccessed)
                {
                    Data = result.ResultObj;
                }
            }
        }
    }
}
