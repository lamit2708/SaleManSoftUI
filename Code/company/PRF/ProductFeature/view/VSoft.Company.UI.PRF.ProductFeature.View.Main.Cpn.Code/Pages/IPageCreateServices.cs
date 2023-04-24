using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Data;

namespace VSoft.Company.UI.PRF.ProductFeature.View.Main.Cpn.Code.Pages
{
    public interface IPageCreateServices : IPageBase
    {
        //string name, string phone, string email, string address, bool gender, int priority
        Task CreateProductFeatures(ProductFeatureDvo productfeature);
    }
}
