using System.Collections.Generic;
using VSoft.Company.DEA.Deal.Business.Dto.Data;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;

namespace VSoft.Company.UI.DEA.Deal.Data.DVO.Extension.DataMethods
{
    public static class DealDtoMethods
    {
        public static DealDvo GetDvo(this DealDto src)
        {
            return new DealDvo()
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
                CreatedDate = src.CreatedDate,
                DealId = src.DealId,
                DealStepId = src.DealStepId,
                UserId = src.UserId,
                OrderId = src.OrderId,
            };
        }

        public static DealDvo[]? GetDvo(this DealDto[]? src)
        {
            if (src == null)
                return null;
            var rs = new List<DealDvo>();
            foreach(var item in src )
            {
                rs.Add(GetDvo(item));
            }
            return rs.ToArray();
        }
    }
}
