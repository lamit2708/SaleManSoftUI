using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;

namespace VSoft.Company.UI.DEA.Deal.View.TestUi.Pages
{
    public partial class TestComponents
    {
        public DealTagDvo DealTagDvo { get; } = new DealTagDvo()
        {
            DealId = 1,
            DealName = "Mua máy tính",
            CustomerName = "Nguyễn Văn Nam",
            CustomerPhone = "076598124",
            StatusDealId = 1,
            PredictPrice = 10000000
        };
    }
}
