using VSoft.Company.PRO.Team.Business.Dto.Data;
using VSoft.Company.UI.PRO.Team.Data.DVO.Data;

namespace VSoft.Company.UI.PRO.Team.Data.DVO.Extension.DataMethods
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
