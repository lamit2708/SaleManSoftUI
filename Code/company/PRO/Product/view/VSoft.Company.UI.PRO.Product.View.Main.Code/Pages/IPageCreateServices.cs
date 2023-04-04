using System.Collections.Generic;
using System.Threading.Tasks;

namespace VSoft.Company.UI.PRO.Product.View.Main.Code.Pages
{
    public interface IPageCreateServices
    {
        List<string> PageMessage { get; }
        bool IsSuccess { get; }
        Task CreateProducts(string name, string description);
    }
}
