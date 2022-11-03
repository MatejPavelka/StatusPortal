namespace StatusPortal.Shared.Dto
{
    public class LineDto
    {
        public int Id { get; set; }
        public string InternalNumber { get; set; }
        public string Description { get; set; }
        public DateTime? RequestedDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public string TrackingUrl { get; set; }
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }

    }
}
