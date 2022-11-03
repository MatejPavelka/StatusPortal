using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StatusPortalServer.Models
{
    public class OrderLine
    {
        [Key]
        public int Id { get; set; }
        public string InternalNumber { get; set; }
        public string Description { get; set; }
        public DateTime? RequestedDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public string TrackingUrl { get; set; }

        public List<OrderStatus> Statuses { get; set; }

        public int OrderId  { get; set; }

    }
}
