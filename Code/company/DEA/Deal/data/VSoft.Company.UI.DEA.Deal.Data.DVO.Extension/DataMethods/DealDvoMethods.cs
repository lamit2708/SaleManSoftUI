using VSoft.Company.DEA.Deal.Business.Dto.Data;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;

namespace VSoft.Company.UI.DEA.Deal.Data.DVO.Extension.DataMethods
{
    public static class DealDvoMethods
    {
        public static DealDto GetDto(this DealDvo src)
        {
            return new DealDto()
            {
                Id = src.Id,
                CreatedDate = src.CreatedDate,
                CustomerId = src.CustomerId,
                DealStepId = src.DealStepId,
                UserId = src.UserId,
                OrderId = src.OrderId,
                Name = src.Name,
                Description = src.Description,
                PridictPrice = src.PridictPrice,
                DateFor = src.DateFor,
                PricePossible = src.PricePossible,
            };
        }
    }
}
