using VSoft.Company.CTM.Customer.Business.Dto.Data;
using VSoft.Company.UI.CTM.Customer.Data.DVO.Data;

namespace VSoft.Company.UI.CTM.Customer.Data.DVO.Extension.DataMethods
{
    public static class CustomerDvoMethods
    {
        public static CustomerDto GetDto(this CustomerDvo src)
        {
            return new CustomerDto()
            {
                Id = src.Id,
                Name = src.Name,
                Phone = src.Phone,
                Address = src.Address,
                CustomerInfoId = src.CustomerInfoId,
                Email = src.Email,
                Gender = src.Gender,
                IsBought = src.IsBought,
                 PriorityId = src.PriorityId,
            };
        }
    }
}
