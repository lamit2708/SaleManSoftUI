using System.Collections.Generic;
using VSoft.Company.DQU.DealQuotation.Business.Dto.Data;
using VSoft.Company.UI.DQU.DealQuotation.Data.DVO.Data;

namespace VSoft.Company.UI.DQU.DealQuotation.Data.DVO.Extension.DataMethods
{
    public static class DealQuotationDtoMethods
    {
        public static DealQuotationDvo GetDvo(this DealQuotationDto src)
        {
            return new DealQuotationDvo()
            {
                Id = src.Id,
                DealId = src.DealId,
                ProductId = src.ProductId,
                Quatitty = src.Quatitty,
                UserId = src.UserId,
                CreatedDate = src.CreatedDate,
            };
        }

        public static DealQuotationDvo[]? GetDvo(this DealQuotationDto[]? src)
        {
            if (src == null)
                return null;
            var rs = new List<DealQuotationDvo>();
            foreach(var item in src )
            {
                rs.Add(GetDvo(item));
            }
            return rs.ToArray();
        }
    }
}
