using System.Threading.Tasks;
using VegunSoft.Framework.Paging.Provider.Request;
using VSoft.Company.UI.TEA.Team.Business.Service.Services;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;
using VSoft.Company.UI.TEA.Team.Data.DVO.Request;
using VSoft.Company.UI.TEA.Team.View.Main.Code.Pages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VSoft.Company.UI.TEA.Team.View.Main.Code.Provider.Pages
{
    public class PageTableServices : IPageTableServices
    {
        protected ITeamBusiness BusinessService { get; set; }
        public List<string> PageMessage { get; private set; } = new List<string>();
        protected string? keySearch { get; set; }
        protected PagingParameters PageParas { get; set; } = new PagingParameters();
        protected List<TeamDvo> Teams { get; set; }
        public PageTableServices(ITeamBusiness service)
        {
            BusinessService = service;
        }

        protected async Task GetTeams()
        {
            var pagingResponse = await BusinessService.GetTableTeam(keySearch, PageParas);
            Tasks = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
            if (pagingResponse.IsSuccessed) 
            { 
            
            }
            else
            {

            }

        }
    }
}
