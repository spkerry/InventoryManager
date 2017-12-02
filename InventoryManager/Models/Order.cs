using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public DateTime ReceivedDate { get; set; }

        public IList<VendorOrder > VendorOrders { get; set; }
    }
}
