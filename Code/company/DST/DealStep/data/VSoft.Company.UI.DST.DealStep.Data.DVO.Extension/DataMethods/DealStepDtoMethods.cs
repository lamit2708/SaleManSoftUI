using System.Collections.Generic;
using VSoft.Company.DST.DealStep.Business.Dto.Data;
using VSoft.Company.UI.DST.DealStep.Data.DVO.Data;

namespace VSoft.Company.UI.DST.DealStep.Data.DVO.Extension.DataMethods
{
    public static class DealStepDtoMethods
    {
        public static DealStepDvo GetDvo(this DealStepDto src)
        {
            return new DealStepDvo()
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description
            };
        }

        public static DealStepDvo[]? GetDvo(this DealStepDto[]? src)
        {
            if (src == null)
                return null;
            var rs = new List<DealStepDvo>();
            foreach(var item in src )
            {
                rs.Add(GetDvo(item));
            }
            return rs.ToArray();
        }
    }
}
