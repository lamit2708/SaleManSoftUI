using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.TEA.Team.Business.Service.Services;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;
using VSoft.Company.UI.TEA.Team.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.TEA.Team.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : PageBase, IPageCreateServices
    {
        protected ITeamBusiness BusinessService { get; set; }

        public PageCreateServices(ITeamBusiness service)
        {
            BusinessService = service;
        }

        public async Task CreateTeams(string name, string description)
        {
            Messages?.Clear();
            if (string.IsNullOrEmpty(name))
            {
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Tên nhóm không được để trống" });
                return;
            }
            var teamDvo = new TeamDvo { Name = name, Description = description };
            var rs = await BusinessService.CreateAsync(teamDvo);
            if (rs.IsSuccessed)
                Messages?.Add(new MMessage() { Type = EMessageType.Success, Message = $"Tạo nhóm \"{rs.ResultObj}\" thành công!" });
            else
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể tạo nhóm \"{name}\"! {rs.Message}" });
        }
    }
}
