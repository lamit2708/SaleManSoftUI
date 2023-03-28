using VegunSoft.Framework.Business.Dto.Response;
using VSoft.Company.UI.TEA.Team.Business.Service.Services;
using VSoft.Company.UI.TEA.Team.Client.Main.Code.Pages;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.Client.Main.Code.Provider.Pages
{
    public class PageCreateServices : IPageCreateServices
    {
        protected ITeamBusiness BusinessService { get; set; }
        public List<string> PageMessage { get; private set; } = new List<string>();
        public PageCreateServices(ITeamBusiness service)
        {
            BusinessService = service;
        }

        public async Task<KeyValuePair<bool, string>> CreateTeams(string name, string description)
        {
            if (string.IsNullOrEmpty(name))
                return new KeyValuePair<bool, string>(false, "Tên Team không được để trống");
            var teamDvo = new TeamDvo { Name = name, Description = description };
            var rs = await BusinessService.CreateAsync(teamDvo);
            var msg = string.Empty;
            if (rs.IsSuccessed)
                msg = $"Tạo Team \"{rs.ResultObj}\" thành công!";
            else
                msg = $"Không thể tạo Team \"{name}\"! {rs.Message}";
            return new KeyValuePair<bool, string>(rs.IsSuccessed, msg) ;
        }
    }
}
