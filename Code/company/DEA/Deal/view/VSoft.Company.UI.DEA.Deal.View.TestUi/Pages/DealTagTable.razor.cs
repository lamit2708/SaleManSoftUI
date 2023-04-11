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

        public List<DealTagDvo> ListDealTag = new List<DealTagDvo>()
        {
            new DealTagDvo()
            {
                DealId = 1,
                DealName = "Mua máy tính",
                CustomerName = "Nguyễn Văn Nam",
                CustomerPhone = "076598124",
                StatusDealId = 1,
                PredictPrice = 10000000
            },
            new DealTagDvo()
            {
                DealId = 2,
                DealName = "Mua laptop",
                CustomerName = "Hoàng Minh Thu",
                CustomerPhone = "345497521",
                StatusDealId = 2,
                PredictPrice = 10000000
            },
            new DealTagDvo()
            {
                DealId = 3,
                DealName = "Thuê văn phòng",
                CustomerName = "Minh Hoàng Dũng",
                CustomerPhone = "085432145",
                StatusDealId = 3,
                PredictPrice = 65000000
            },
            new DealTagDvo()
            {
                DealId = 4,
                DealName = "Mua xe máy",
                CustomerName = "Đinh Tiến Huy",
                CustomerPhone = "0126475975",
                StatusDealId = 1,
                PredictPrice = 4500000
            },
            new DealTagDvo()
            {
                DealId = 5,
                DealName = "Thuê Server",
                CustomerName = "Huỳnh Nhật Tân",
                CustomerPhone = "090452758",
                StatusDealId = 4,
                PredictPrice = 13000000
            },
            new DealTagDvo()
            {
                DealId = 6,
                DealName = "Bán nhà",
                CustomerName = "Đào Duy Khiêm",
                CustomerPhone = "075246235",
                StatusDealId = 5,
                PredictPrice = 2300000000
            },
            new DealTagDvo()
            {
                DealId = 7,
                DealName = "Mua tablet",
                CustomerName = "Đoàn Nhật Tân",
                CustomerPhone = "094246215",
                StatusDealId = 3,
                PredictPrice = 20000000
            },
    };
    }
}
