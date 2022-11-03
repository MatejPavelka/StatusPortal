using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusPortalServer.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } 
        public string OrderNumber   { get; set; }
        public string ShipToCompany { get; set; }  
        public string Process { get; set; } 
        public List<OrderLine> Lines { get; set; }
    }
}
