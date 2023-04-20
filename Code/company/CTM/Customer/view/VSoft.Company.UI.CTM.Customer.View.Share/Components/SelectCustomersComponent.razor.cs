using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSoft.Company.UI.CTM.Customer.Business.Service.Services;
using VSoft.Company.UI.CTM.Customer.Data.DVO.Data;

namespace VSoft.Company.UI.CTM.Customer.View.Share.Components
{
    public partial class SelectCustomersComponent
    {
        [Inject] ICustomerBusiness BusinessService { get; set; }

        List<CustomerDvo> Data { get; set; }

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
