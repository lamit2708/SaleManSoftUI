using System.Collections.Generic;
using VSoft.Company.DEA.Deal.Business.Dto.Data;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;
using VSoft.Company.VDT.VDealTag.Business.Dto.Data;

namespace VSoft.Company.UI.DEA.Deal.Data.DVO.Extension.DataMethods
{
    public static class DealTagDtoMethods
    {
        public static DealTagDvo GetDvo(this VDealTagDto src)
        {
            return new DealTagDvo()
            {
                Id = src.Id,
                DealName = src.DealName,
                CustomerId = src.CustomerId,
                CustomerName = src.CustomerName,
                CustomerPhone = src.CustomerPhone,
                PridictPrice = src.PridictPrice,
                DealStepId = src.DealStepId,
                UserId = src.UserId,
                UserName = src.UserName,
                TeamId = src.TeamId,
                DateFor = src.DateFor,
            };
        }

        public static DealTagDvo[]? GetDvo(this VDealTagDto[]? src)
        {
            if (src == null)
                return null;
            var rs = new List<DealTagDvo>();
            foreach (var item in src)
            {
                rs.Add(GetDvo(item));
            }
            return rs.ToArray();
        }
    }
}
