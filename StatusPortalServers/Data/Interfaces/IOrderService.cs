using StatusPortal.Shared.Dto;
using System.Collections.Generic;
namespace StatusPortalServer.Data.Interfaces
{
    public class IOrderService
    {
        public IEnumerable<OrderDto> GetByShipToCompany(string company);
    }
}
