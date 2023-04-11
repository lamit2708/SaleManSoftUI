using VSoft.Company.USR.User.Business.Dto.Data;
using VSoft.Company.UI.USR.User.Data.DVO.Data;

namespace VSoft.Company.UI.USR.User.Data.DVO.Extension.DataMethods
{
    public static class UserDvoMethods
    {
        public static UserDto GetDto(this UserDvo src)
        {
            return new UserDto()
            {
                Id = src.Id,
                Name = src.Name,
                Phone = src.Phone,
                Username = src.Username,
                Password = src.Password,
                Email = src.Email,
                TeamId = src.TeamId,
            };
        }
    }
}
