using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Response;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.Client.Main.Code.Pages
{
    public interface IPageCreateServices
    {
        Task<KeyValuePair<bool, string>> CreateTeams(string name, string description);
    }
}
