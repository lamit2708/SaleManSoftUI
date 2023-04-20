using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.USR.User.Business.Service.Services;
using VSoft.Company.UI.USR.User.Data.DVO.Data;
using VSoft.Company.UI.USR.User.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.USR.User.View.Main.Code.Provider.Pages
{
    public class PageCreateServices : PageBase, IPageCreateServices
    {
        protected IUserBusiness BusinessService { get; set; }

        public PageCreateServices(IUserBusiness service)
        {
            BusinessService = service;
        }

        public async Task CreateUsers(UserDvo userDvo)
        {
            Messages?.Clear();
            if (string.IsNullOrEmpty(userDvo.Username) || string.IsNullOrEmpty(userDvo.Password))
            {
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = "Tên tài khoản / mật khẩu không được để trống" });
                return;
            }
            var rs = await BusinessService.CreateAsync(userDvo);
            if (rs.IsSuccessed)
                Messages?.Add(new MMessage() { Type = EMessageType.Success, Message = $"Tạo tài khoản \"{rs.ResultObj}\" thành công!" });
            else
                Messages?.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể tạo tài khoản \"{userDvo.Username}\"! {rs.Message}" });
        }
    }
}
