using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Request;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UCU.UserCustomer.Business.Dto.Data;
using VSoft.Company.UCU.UserCustomer.Business.Dto.Request;
using VSoft.Company.UCU.UserCustomer.Client.Services;

using VSoft.Company.TEA.Team.Client.Services;
using VSoft.Company.UI.UCU.UserCustomer.Business.Service.Services;

using VSoft.Company.USR.User.Client.Services;
using VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Data;
using VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Extension.DataMethods;

namespace VSoft.Company.UI.UCU.UserCustomer.Business.Service.Provider.Services
{
    public class UserCustomerBusiness : IUserCustomerBusiness
    {
        private IUserCustomerClient ClientService;
        private IUserClient ClientUserService;
        private ITeamClient ClientTeamService;
        public UserCustomerBusiness(IUserCustomerClient clientService,  IUserClient usrClient, ITeamClient teamClient)
        {
            ClientService = clientService;
            ClientUserService = usrClient;
            ClientTeamService = teamClient;
        }

        public async Task<MDvoResult<string>> CreateAsync(UserCustomerDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new UserCustomerInsertDtoRequest()
            {
                Data = teamDvo.GetDto(),
            });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                    return new MDvoResultSuccess<string>(apiRs.Data.CustomerId.ToString());
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<PagedList<UserCustomerDvo>>> GetTableUserCustomer(string keyWord, PagingParameters pageParameter)
        {
            //Client làm hàm trả về MDtoResponse<PagedList<UserCustomerDto>>
            var request = new UserCustomerTableKeySearchDtoRequest()
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
                    var rs = new PagedList<UserCustomerDvo>()
                    {
                        MetaData = apiRs.MetaData,
                        Items = teamDvos
                    };
                    return new MDvoResultSuccess<PagedList<UserCustomerDvo>>(rs);
                }
                else
                    return new MDvoResultError<PagedList<UserCustomerDvo>>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<string>> DeleteUserCustomer(int id)
        {
            var apiRs = await ClientService.DeleteAsync(new UserCustomerDeleteDtoRequest()
            {
                Id = id,
            });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDelete = apiRs.Data;
                    return new MDvoResultSuccess<string>(teamDelete.CustomerId+" "+teamDelete.UserId);
                }
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<UserCustomerDvo>> GetUserCustomer(int valId)
        {
           // int valId = id ?? 0;

            var apiRs = await ClientService.FindAsync(new MDtoRequestFindByInt() { Id = valId });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDvo = apiRs.Data.GetDvo();
                    return new MDvoResultSuccess<UserCustomerDvo>(teamDvo);
                }
                else
                    return new MDvoResultError<UserCustomerDvo>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<string>> UpdateUserCustomer(UserCustomerDvo teamDvo)
        {
            var teamDto = teamDvo.GetDto();
            var apiRs = await ClientService.UpdateAsync(new UserCustomerUpdateDtoRequest() { Data = teamDto });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamUpdate = apiRs.Data;
                    return new MDvoResultSuccess<string>(teamUpdate.CustomerId.ToString());
                }
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

       
       

      
        public async Task<MDvoResult<Dictionary<int, string>>> GetUser()
        {
            var rs = await ClientUserService.GetAll();
            if (rs != null)
            {
                if (rs.IsSuccess)
                {
                    var dealStep = new Dictionary<int, string>();
                    foreach (var ds in rs.Data)
                        dealStep.Add(ds.Key, ds.Value);
                    return new MDvoResultSuccess<Dictionary<int, string>>(dealStep);
                }
                else
                    return new MDvoResultError<Dictionary<int, string>>(rs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<Dictionary<int, string>>> GetTeam()
        {
            var rs = await ClientTeamService.GetAll();
            if (rs != null)
            {
                if (rs.IsSuccess)
                {
                    var dealStep = new Dictionary<int, string>();
                    foreach (var ds in rs.Data)
                        dealStep.Add(ds.Key, ds.Value);
                    return new MDvoResultSuccess<Dictionary<int, string>>(dealStep);
                }
                else
                    return new MDvoResultError<Dictionary<int, string>>(rs.Message);
            }
            return null;
        }
    }
}
