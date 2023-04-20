using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Request;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.CTM.Customer.Business.Dto.Data;
using VSoft.Company.CTM.Customer.Business.Dto.Request;
using VSoft.Company.CTM.Customer.Client.Services;
using VSoft.Company.UI.CTM.Customer.Business.Service.Services;
using VSoft.Company.UI.CTM.Customer.Data.DVO.Data;
using VSoft.Company.UI.CTM.Customer.Data.DVO.Extension.DataMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VSoft.Company.UI.CTM.Customer.Business.Service.Provider.Services
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private ICustomerClient ClientService;
        public CustomerBusiness(ICustomerClient clientService)
        {
            ClientService = clientService;
        }

        public async Task<MDvoResult<string>> CreateAsync(CustomerDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new CustomerInsertDtoRequest()
            {
                Data = teamDvo.GetDto(),
            });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                    return new MDvoResultSuccess<string>(apiRs.Data.Name);
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<PagedList<CustomerDvo>>> GetTableCustomer(string keyWord, PagingParameters pageParameter)
        {
            //Client làm hàm trả về MDtoResponse<PagedList<CustomerDto>>
            var request = new CustomerTableKeySearchDtoRequest()
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
                    var rs = new PagedList<CustomerDvo>()
                    {
                        MetaData = apiRs.MetaData,
                        Items = teamDvos
                    };
                    return new MDvoResultSuccess<PagedList<CustomerDvo>>(rs);
                }
                else
                    return new MDvoResultError<PagedList<CustomerDvo>>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<string>> DeleteCustomer(int id)
        {
            var apiRs = await ClientService.DeleteAsync(new CustomerDeleteDtoRequest()
            {
                Id = id,
            });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDelete = apiRs.Data;
                    return new MDvoResultSuccess<string>(teamDelete.Name);
                }
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<CustomerDvo>> GetCustomer(string id)
        {
            var apiRs = await ClientService.FindAsync(new MDtoRequestFindByString() { Id = id });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDvo = apiRs.Data.GetDvo();
                    return new MDvoResultSuccess<CustomerDvo>(teamDvo);
                }
                else
                    return new MDvoResultError<CustomerDvo>(apiRs.Message);
            }

            return null;
        }

        public async Task<MDvoResult<string>> UpdateCustomer(CustomerDvo teamDvo)
        {
            var teamDto = teamDvo.GetDto();
            var apiRs = await ClientService.UpdateAsync(new CustomerUpdateDtoRequest() { Data = teamDto });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamUpdate = apiRs.Data;
                    return new MDvoResultSuccess<string>(teamUpdate.Name);
                }
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<List<CustomerDvo>>> GetAll()
        {
            var apiRs = await ClientService.GetAll();
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var rs = apiRs.Data;
                    var dat = rs.GetDvo().ToList();
                    return new MDvoResultSuccess<List<CustomerDvo>>(dat);
                }
                else
                    return new MDvoResultError<List<CustomerDvo>>(apiRs.Message);
            }
            //var rs = new CustomerDto[]
            //{
            //    new CustomerDto() { Id = 1, Name = "Nguyễn Văn Hoàng"},
            //    new CustomerDto() { Id = 2, Name = "Bùi Văn Ba"},
            //    new CustomerDto() { Id = 3, Name = "Đinh Văn Tuấn"},
            //};
            //return new MDvoResultSuccess<List<CustomerDvo>>(rs.GetDvo().ToList());
            return null;
        }
    }
}
