using System.Collections.Generic;
using VSoft.Company.USR.User.Business.Dto.Data;
using VSoft.Company.UI.USR.User.Data.DVO.Data;

namespace VSoft.Company.UI.USR.User.Data.DVO.Extension.DataMethods
{
    public static class UserDtoMethods
    {
        public static UserDvo GetDvo(this UserDto src)
        {
            return new UserDvo()
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

        public static UserDvo[]? GetDvo(this UserDto[]? src)
        {
            if (src == null)
                return null;
            var rs = new List<UserDvo>();
            foreach(var item in src )
            {
                rs.Add(GetDvo(item));
            }
            return rs.ToArray();
        }
    }
}
