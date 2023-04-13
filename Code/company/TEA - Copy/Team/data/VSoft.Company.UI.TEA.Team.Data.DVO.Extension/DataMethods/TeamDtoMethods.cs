using System.Collections.Generic;
using VSoft.Company.TEA.Team.Business.Dto.Data;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.Data.DVO.Extension.DataMethods
{
    public static class TeamDtoMethods
    {
        public static TeamDvo GetDvo(this TeamDto src)
        {
            return new TeamDvo()
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
            };
        }

        public static TeamDvo[]? GetDvo(this TeamDto[]? src)
        {
            if (src == null)
                return null;
            var rs = new List<TeamDvo>();
            foreach(var item in src )
            {
                rs.Add(GetDvo(item));
            }
            return rs.ToArray();
        }
    }
}
