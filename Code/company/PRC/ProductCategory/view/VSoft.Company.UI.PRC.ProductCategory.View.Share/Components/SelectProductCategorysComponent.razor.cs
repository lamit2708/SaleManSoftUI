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

        private int _value;

        [Parameter]
        public int SelectedId
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                SelectedIdChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<int> SelectedIdChanged { get; set; }
    }
}
