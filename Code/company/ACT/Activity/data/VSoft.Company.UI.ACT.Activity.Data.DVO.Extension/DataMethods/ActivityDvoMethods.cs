using VSoft.Company.ACT.Activity.Business.Dto.Data;
using VSoft.Company.UI.ACT.Activity.Data.DVO.Data;

namespace VSoft.Company.UI.ACT.Activity.Data.DVO.Extension.DataMethods
{
    public static class ActivityDvoMethods
    {
        public static ActivityDto GetDto(this ActivityDvo src)
        {
            return new ActivityDto()
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
    }
}
