using StatusPortalServer.Data.Interfaces;

namespace StatusPortalServer.Data
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public OrderService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        private List<OrderDto> ToResponse(IQueryable<Models.Order> orders) => _mapper.Map<List<OrderDto>>(orders.OrderBy(x => x.OrderNumber));

        public IEnumerable<OrderDto> GetByShipToCompany(string company)
        {
            return string.isnullorempty(company) ? Enumerable.Empty<OrderDto>() : ToResponse(_db.Orders.Where(x => x.company == company));
        }
    }
}
