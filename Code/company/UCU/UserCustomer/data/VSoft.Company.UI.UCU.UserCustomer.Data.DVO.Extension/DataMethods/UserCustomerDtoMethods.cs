using System.Collections.Generic;
using VSoft.Company.UCU.UserCustomer.Business.Dto.Data;
using VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Data;

namespace VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Extension.DataMethods
{
    public static class UserCustomerDtoMethods
    {
        public static UserCustomerDvo GetDvo(this UserCustomerDto src)
        {
            return new UserCustomerDvo()
            {
                Id = src.Id,
                CreatedDateUser = src.CreatedDateUser,
                CreatedDateTeam=src.CreatedDateTeam,
                CustomerId = src.CustomerId,
                UserId = src.UserId ?? 0,
                TeamId = src.TeamId ?? 0,
                UserFullName = src.UserFullName,
                CustomerFullName = src.CustomerFullName,
                TeamName = src.TeamName,
            };
        }

        public static UserCustomerDvo[]? GetDvo(this UserCustomerDto[]? src)
        {
            if (src == null)
                return null;
            var rs = new List<UserCustomerDvo>();
            foreach (var item in src)
            {
                rs.Add(GetDvo(item));
            }
            return rs.ToArray();
        }
    }
}
