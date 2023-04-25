using VSoft.Company.UCU.UserCustomer.Business.Dto.Data;
using VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Data;

namespace VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Extension.DataMethods
{
    public static class UserCustomerDvoMethods
    {
        public static UserCustomerDto GetDto(this UserCustomerDvo src)
        {
            return new UserCustomerDto()
            {
                Id = src.Id,
                
                CreatedDateUser = src.CreatedDateUser ?? System.DateTime.Now,
                CreatedDateTeam= src.CreatedDateTeam ?? System.DateTime.Now,
                CustomerId = src.CustomerId,
                UserId = src.UserId,
                TeamId = src.TeamId == 0 ? null: src.TeamId,

               // UserFullName = src.UserFullName,
                //CustomerFullName = src.CustomerFullName,
            };
        }
    }
}
