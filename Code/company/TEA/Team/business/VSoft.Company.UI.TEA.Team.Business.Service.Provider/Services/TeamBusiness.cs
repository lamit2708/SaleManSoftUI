using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Response;
using VSoft.Company.TEA.Team.Business.Dto.Request;
using VSoft.Company.TEA.Team.Client.Services;
using VSoft.Company.UI.TEA.Team.Business.Service.Services;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;
using VSoft.Company.UI.TEA.Team.Data.DVO.Extension.DataMethods;

namespace VSoft.Company.UI.TEA.Team.Business.Service.Provider.Services
{
    public class TeamBusiness : ITeamBusiness
    {
        private ITeamClient ClientService;
        public TeamBusiness(ITeamClient clientService)
        {
            ClientService = clientService;
        }

        public async Task<MDtoResult<string>> CreateAsync(TeamDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new TeamInsertDtoRequest()
            {
                Data = teamDvo.GetDto(),
            });
            if (apiRs == null)
            {
                if (apiRs.IsSuccess)
                    return new MDtoResultSuccess<string>(apiRs.Data.Name);
                else
                    return new MDtoResultError<string>(apiRs.Message);
            }
            return null;
        }

    }
}
