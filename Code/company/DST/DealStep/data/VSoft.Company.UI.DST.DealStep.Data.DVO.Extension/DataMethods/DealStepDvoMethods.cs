using VSoft.Company.DST.DealStep.Business.Dto.Data;
using VSoft.Company.UI.DST.DealStep.Data.DVO.Data;

namespace VSoft.Company.UI.DST.DealStep.Data.DVO.Extension.DataMethods
{
    public static class DealStepDvoMethods
    {
        public static DealStepDto GetDto(this DealStepDvo src)
        {
            return new DealStepDto()
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description
            };
        }
    }
}
