using VSoft.Company.DQU.DealQuotation.Business.Dto.Data;
using VSoft.Company.UI.DQU.DealQuotation.Data.DVO.Data;

namespace VSoft.Company.UI.DQU.DealQuotation.Data.DVO.Extension.DataMethods
{
    public static class DealQuotationDvoMethods
    {
        public static DealQuotationDto GetDto(this DealQuotationDvo src)
        {
            return new DealQuotationDto()
            {
                Id = src.Id,
                DealId = src.DealId,
                ProductId = src.ProductId,
                Quatitty = src.Quatitty,
                UserId = src.UserId,
                CreatedDate = src.CreatedDate,
            };
        }
    }
}
