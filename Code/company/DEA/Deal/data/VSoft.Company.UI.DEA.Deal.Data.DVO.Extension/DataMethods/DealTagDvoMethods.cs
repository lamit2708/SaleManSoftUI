using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;
using VSoft.Company.VDT.VDealTag.Business.Dto.Data;

namespace VSoft.Company.UI.DEA.Deal.Data.DVO.Extension.DataMethods
{
    public static class DealTagDvoMethods
    {
        public static VDealTagDto GetDto(this DealTagDvo src)
        {
            return new VDealTagDto()
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
    }
}
