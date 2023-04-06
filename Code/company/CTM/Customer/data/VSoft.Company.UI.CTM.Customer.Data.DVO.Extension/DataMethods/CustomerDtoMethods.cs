using System.Collections.Generic;
using VSoft.Company.CTM.Customer.Business.Dto.Data;
using VSoft.Company.UI.CTM.Customer.Data.DVO.Data;

namespace VSoft.Company.UI.CTM.Customer.Data.DVO.Extension.DataMethods
{
    public static class CustomerDtoMethods
    {
        public static CustomerDvo GetDvo(this CustomerDto src)
        {
            return new CustomerDvo()
            {
                Id = src.Id,
                Name = src.Name,
                Phone = src.Phone,
                Email = src.Email,
                Address = src.Address,
                Gender = src.Gender,
                PriorityId = src.PriorityId,
                CustomerInfoId = src.CustomerInfoId,
                IsBought    = src.IsBought,

            };
        }

        public static CustomerDvo[]? GetDvo(this CustomerDto[]? src)
        {
            if (src == null)
                return null;
            var rs = new List<CustomerDvo>();
            foreach (var item in src)
            {
                rs.Add(GetDvo(item));
            }
            return rs.ToArray();
        }
    }
}
