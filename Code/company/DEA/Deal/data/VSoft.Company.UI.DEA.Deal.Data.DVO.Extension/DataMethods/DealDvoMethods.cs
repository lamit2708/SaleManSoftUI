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
                Name = src.Name,
                Description = src.Description,
                CreatedDate = src.CreatedDate,
                DealId = src.DealId,
                DealStepId = src.DealStepId,
                UserId = src.UserId,
                OrderId = src.OrderId,
            };
        }
    }
}
