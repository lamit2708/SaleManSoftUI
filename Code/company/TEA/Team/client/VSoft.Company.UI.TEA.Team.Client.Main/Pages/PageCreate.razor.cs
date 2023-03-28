using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using VSoft.Company.UI.TEA.Team.Client.Main.Code.Pages;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.Client.Main.Pages
{
    public partial class PageCreate
    {
        [Inject] protected IPageCreateServices PageServices { get; set; }
        protected string? Name;
        protected string? Description;

        private async Task SubmitTask(EditContext context)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var isCreate = await PageServices.CreateTeams(new TeamDvo() { Name = Name, Description = Description });
                if (isCreate)
                {

                }
                else
                {

                }
            }
            else
            {

            }
        }
    }
}
