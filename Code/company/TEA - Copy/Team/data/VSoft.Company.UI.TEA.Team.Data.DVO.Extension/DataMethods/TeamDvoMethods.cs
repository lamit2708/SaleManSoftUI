using VSoft.Company.TEA.Team.Business.Dto.Data;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.Data.DVO.Extension.DataMethods
{
    public static class TeamDvoMethods
    {
        public static TeamDto GetDto(this TeamDvo src)
        {
            return new TeamDto()
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
            };
        }
    }
}
