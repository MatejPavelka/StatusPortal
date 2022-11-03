using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusPortalServer.Models
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }    
        public bool Approved { get; set; }
        public bool Sent { get; set; }
        public bool Received { get; set; }
        public int OrderLineId { get; set; }

    }
}
