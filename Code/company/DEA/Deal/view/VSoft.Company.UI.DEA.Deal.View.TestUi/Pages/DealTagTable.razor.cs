using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;

namespace VSoft.Company.UI.DEA.Deal.View.TestUi.Pages
{
    public partial class DealTagTable
    {
        public Dictionary<string, string> DealStepDict = new Dictionary<string, string>()
        {
            { "1", "Open Deal"},
            { "2", "Lấy yêu cầu"},
            { "3", "Báo giá"},
            { "4", "Tư vấn"},
            { "5", "Won"},
        };

        public List<DealTagDvo> ListDealTag = new List<DealTagDvo>();
    }
}
