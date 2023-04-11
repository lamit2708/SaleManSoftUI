using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.USR.User.Business.Service.Services;
using VSoft.Company.UI.USR.User.Data.DVO.Data;
using VSoft.Company.UI.USR.User.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.USR.User.View.Main.Code.Provider.Pages
{
    public class PageUpdateServices : PageBase, IPageUpdateServices
    {
        protected IUserBusiness BusinessService { get; set; }
        public UserDvo? User { get; private set; }
        public PageUpdateServices(IUserBusiness service)
        {
            BusinessService = service;
        }
        public async Task OnInitializedAsync(string teamId)
        {
            var pagingRs = await BusinessService.GetUser(teamId);
            if (pagingRs.IsSuccessed)
            {
                var data = pagingRs.ResultObj;
                User = data;
            }
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = pagingRs.Message });
        }

        public async Task OnUpdateUser(string teamId, string name, string description)
        {
            ClearAllMessage();
            var id = Int32.TryParse(teamId, out var idInt) ? idInt : 0;
            if (id != 0)
            {
                var pagingRs = await BusinessService.UpdateUser(new UserDvo()
                {
                    Id = id,
                    Name = name,
                    Description = description
                });
                if (pagingRs.IsSuccessed)
                {
                    var data = pagingRs.ResultObj;
                    Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Cập nhật User {data} thành công!" });
                }
                else
                    Messages.Add(new MMessage() { Type = EMessageType.Error, Message = pagingRs.Message });
            }
        }

        protected void ClearAllMessage()
        {
            Messages?.Clear();
        }
    }
}
