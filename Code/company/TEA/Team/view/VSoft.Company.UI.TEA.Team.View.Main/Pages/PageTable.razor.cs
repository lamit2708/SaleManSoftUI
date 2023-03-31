using VSoft.Company.UI.TEA.Team.Data.DVO.Data;
using VegunSoft.Framework.Ui.Component.Popups;
using VegunSoft.Framework.Paging.Provider.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using VSoft.Company.UI.TEA.Team.View.Main.Code.Pages;

namespace VSoft.Company.UI.TEA.Team.View.Main.Pages
{
    public partial class PageTable
    {
        [Inject] protected IPageTableServices PageServices { get; set; }
        [Inject] IToastService ToastService { get; set; }
        protected List<TeamDvo>? Teams;
        protected Confirmation? DeleteConfirmation { set; get; }
        protected int DeleteId { set; get; }
        public MetaData MetaData { get; set; } = new MetaData();
        protected string? KeySearch { get; set; }
        protected PagingParameters PagingParameters = new PagingParameters();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }


        
    }
}
