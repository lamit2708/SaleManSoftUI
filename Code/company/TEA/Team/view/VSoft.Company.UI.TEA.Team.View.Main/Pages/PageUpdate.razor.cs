using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.View.Main.Pages
{
    public partial class PageUpdate
    {
        [Parameter]
        public string TeamId { set; get; }

        private TeamDvo Team;

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async Task SubmitTask(EditContext context)
        {

        }
    }
}
