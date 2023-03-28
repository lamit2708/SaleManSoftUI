using VSoft.Company.UI.TEA.Team.Data.DVO.Data;
using VegunSoft.Framework.Ui.Component.Popups;
using VegunSoft.Framework.Paging.Provider.Response;

namespace VSoft.Company.UI.TEA.Team.Client.Main.Pages
{
    public partial class PageTable
    {
        private List<TeamDvo>? Teams;
        protected Confirmation? DeleteConfirmation { set; get; }
        private int DeleteId { set; get; }
        public MetaData MetaData { get; set; } = new MetaData();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        public async Task SearchTask(string keyword)
        {

        }

        public async Task OnConfirmDeleteTask(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                
            }
        }

        public void OnDeleteTask(int deleteId)
        {
            DeleteId = deleteId;
            DeleteConfirmation.Show();
        }

        private async Task SelectedPage(int page)
        {
            
        }
    }
}
