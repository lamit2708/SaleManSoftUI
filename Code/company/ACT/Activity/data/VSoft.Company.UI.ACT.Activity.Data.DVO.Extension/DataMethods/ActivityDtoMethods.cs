using System.Collections.Generic;
using VSoft.Company.ACT.Activity.Business.Dto.Data;
using VSoft.Company.UI.ACT.Activity.Data.DVO.Data;

namespace VSoft.Company.UI.ACT.Activity.Data.DVO.Extension.DataMethods
{
    public static class ActivityDtoMethods
    {
        public static ActivityDvo GetDvo(this ActivityDto src)
        {
            return new ActivityDvo()
            {
                Id = src.Id,
                Name = src.Name,
                Content = src.Content,
                ActivityType = src.ActivityType,
                Date = src.Date,
                From = src.From,
                To = src.To,
                ToWho = src.ToWho,
                SubType = src.SubType,
                CreatedDate = src.CreatedDate,
                CreatedUser = src.CreatedUser,
            };
        }

        public static ActivityDvo[]? GetDvo(this ActivityDto[]? src)
        {
            if (src == null)
                return null;
            var rs = new List<ActivityDvo>();
            foreach(var item in src )
            {
                rs.Add(GetDvo(item));
            }
            return rs.ToArray();
        }
    }
}
