using System;
using VegunSoft.Framework.Business.Dto.Response;
using VSoft.Company.TEA.Team.Business.Dto.Response;
using VSoft.Company.UI.TEA.Team.Data.DVO.Extension.DataMethods;
using VSoft.Company.UI.TEA.Team.Data.DVO.Response;

namespace VSoft.Company.UI.TEA.Team.Data.DVO.Extension.RequestMethods
{
    public static class TeamDtoRequestMethods
    {
        public static TeamDataDvoResponse GetDataDvo(this TeamDataDtoResponse src)
        {
            var rs = CloneResponse<TeamDataDvoResponse>(src) as TeamDataDvoResponse;
            return rs;
        }

        public static TeamDeleteDvoResponse GetDeleteDvo(this TeamDeleteDtoResponse src)
        {
            var rs = CloneResponse<TeamDeleteDvoResponse>(src) as TeamDeleteDvoResponse;
            rs.Data = src.Data.GetDvo();
            return rs;
        }

        public static TeamDeleteRangeDvoResponse GetDeleteRangeDvo(this TeamDeleteRangeDtoResponse src)
        {
            var rs = CloneResponse<TeamDeleteRangeDvoResponse>(src) as TeamDeleteRangeDvoResponse;
            rs.Data = src.Data.GetDvo();
            rs.Total = src.Total;
            return rs;
        }

        public static TeamFilterDvoResponse GetFilterDvo(this TeamFilterDtoResponse src)
        {
            var rs = CloneResponse<TeamFilterDvoResponse>(src) as TeamFilterDvoResponse;
            return rs;
        }

        public static TeamInsertDvoResponse GetInsertDvo(this TeamInsertDtoResponse src)
        {
            var rs = CloneResponse<TeamInsertDvoResponse>(src) as TeamInsertDvoResponse;
            rs.Data = src.Data.GetDvo();
            return rs;
        }

        public static TeamInsertRangeDvoResponse GetInsertRangeDvo(this TeamInsertRangeDtoResponse src)
        {
            var rs = CloneResponse<TeamInsertRangeDvoResponse>(src) as TeamInsertRangeDvoResponse;
            rs.Data = src.Data.GetDvo();
            rs.Total = src.Total;
            return rs;
        }

        public static TeamRemoveDvoResponse GetRemoveDvo(this TeamRemoveDtoResponse src)
        {
            var rs = CloneResponse<TeamRemoveDvoResponse>(src) as TeamRemoveDvoResponse;
            return rs;
        }

        public static TeamSaveRangeDvoResponse GetSaveRangeDvo(this TeamSaveRangeDtoResponse src)
        {
            var rs = CloneResponse<TeamSaveRangeDvoResponse>(src) as TeamSaveRangeDvoResponse;
            rs.CreatedData = src.CreatedData.GetDvo();
            rs.UpdatedData = src.UpdatedData.GetDvo();
            rs.DeletedData = src.DeletedData.GetDvo();
            rs.TotalCreated = src.TotalCreated;
            rs.TotalUpdated = src.TotalUpdated;
            rs.TotalDeleted = src.TotalDeleted;
            return rs;
        }

        public static TeamUpdateDvoResponse GetUpdateDvo(this TeamUpdateDtoResponse src)
        {
            var rs = CloneResponse<TeamUpdateDvoResponse>(src) as TeamUpdateDvoResponse;
            rs.Data = src.Data.GetDvo();
            return rs;
        }

        public static TeamUpdateRangeDvoResponse GetUpdateRangeDvo(this TeamUpdateRangeDtoResponse src)
        {
            var rs = CloneResponse<TeamUpdateRangeDvoResponse>(src) as TeamUpdateRangeDvoResponse;
            rs.Data = src.Data.GetDvo();
            rs.Total = src.Total;
            return rs;
        }

        public static MDtoResponse CloneResponse<T>(MDtoResponse response) where T : MDtoResponse
        {
            var rs = (T)Activator.CreateInstance(typeof(T), new object[] { });
            rs.Code = response.Code;
            rs.IsSuccess = response.IsSuccess;
            rs.DateTime = response.DateTime;
            rs.FunctionName = response.FunctionName;
            rs.Message = response.Message;
            return rs;
        }
    }
}
