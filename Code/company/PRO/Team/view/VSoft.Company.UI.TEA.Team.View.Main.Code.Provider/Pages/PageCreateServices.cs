using VSoft.Company.UI.PRO.Team.Business.Service.Services;
using VSoft.Company.UI.PRO.Team.View.Main.Code.Pages;
using VSoft.Company.UI.PRO.Team.Data.DVO.Data;

namespace VSoft.Company.UI.PRO.Team.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : IPageCreateServices
    {
        protected ITeamBusiness BusinessService { get; set; }
        public List<string> PageMessage { get; private set; } = new List<string>();
        public bool IsSuccess { get; private set; }

        public PageCreateServices(ITeamBusiness service)
        {
            BusinessService = service;
        }

        public async Task CreateTeams(string name, string description)
        {
            PageMessage?.Clear();
            if (string.IsNullOrEmpty(name))
            {
                IsSuccess = false;
                PageMessage[0] = "Tên Team không được để trống";
                return;
            }
            var teamDvo = new TeamDvo { Name = name, Description = description };
            var rs = await BusinessService.CreateAsync(teamDvo);
            if (rs.IsSuccessed)
                PageMessage.Add($"Tạo Team \"{rs.ResultObj}\" thành công!");
            else
                PageMessage.Add($"Không thể tạo Team \"{name}\"! {rs.Message}");
            IsSuccess = rs.IsSuccessed;
        }
    }
}
