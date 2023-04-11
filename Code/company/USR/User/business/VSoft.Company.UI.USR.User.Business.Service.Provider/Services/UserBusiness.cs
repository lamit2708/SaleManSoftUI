using System;
using System.Linq;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Request;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.USR.User.Business.Dto.Request;
using VSoft.Company.USR.User.Client.Services;
using VSoft.Company.UI.USR.User.Business.Service.Services;
using VSoft.Company.UI.USR.User.Data.DVO.Data;
using VSoft.Company.UI.USR.User.Data.DVO.Extension.DataMethods;

namespace VSoft.Company.UI.USR.User.Business.Service.Provider.Services
{
    public class UserBusiness : IUserBusiness
    {
        private IUserClient ClientService;
        public UserBusiness(IUserClient clientService)
        {
            ClientService = clientService;
        }

        public async Task<MDvoResult<string>> CreateAsync(UserDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new UserInsertDtoRequest()
            {
                Data = teamDvo.GetDto(),
            });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                    return new MDvoResultSuccess<string>(apiRs.Data.Name);
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<PagedList<UserDvo>>> GetTableUser(string keyWord, PagingParameters pageParameter)
        {
            //Client làm hàm trả về MDtoResponse<PagedList<UserDto>>
            var request = new UserTableKeySearchDtoRequest()
            {
                Data = keyWord,
                PagingParams = pageParameter,
            };
            var apiRs = await ClientService.GetTableByKeyword(request);
            
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDvos = apiRs.Data.GetDvo().ToList();
                    var rs = new PagedList<UserDvo>()
                    {
                        MetaData = apiRs.MetaData,
                        Items = teamDvos
                    };
                    return new MDvoResultSuccess<PagedList<UserDvo>>(rs);
                }
                else
                    return new MDvoResultError<PagedList<UserDvo>>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<string>> DeleteUser(int id)
        {
            var apiRs = await ClientService.DeleteAsync(new UserDeleteDtoRequest()
            {
                Id = id,
            });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDelete = apiRs.Data;
                    return new MDvoResultSuccess<string>(teamDelete.Name);
                }
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<UserDvo>> GetUser(string id)
        {
            var idInt = Int32.TryParse(id, out var teamId) ? teamId : 0;
            if (idInt != 0)
            {
                var apiRs = await ClientService.FindAsync(new MDtoRequestFindByInt() { Id = idInt });
                if (apiRs != null)
                {
                    if (apiRs.IsSuccess)
                    {
                        var teamDvo = apiRs.Data.GetDvo();
                        return new MDvoResultSuccess<UserDvo>(teamDvo);
                    }
                    else
                        return new MDvoResultError<UserDvo>(apiRs.Message);
                }
            }
            return null;
        }

        public async Task<MDvoResult<string>> UpdateUser(UserDvo teamDvo)
        {
            var teamDto = teamDvo.GetDto();
            var apiRs = await ClientService.UpdateAsync(new UserUpdateDtoRequest() { Data = teamDto });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamUpdate = apiRs.Data;
                    return new MDvoResultSuccess<string>(teamUpdate.Name);
                }
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }
    }
}
