using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReceivedDate { get; set; }

        public IList<InventoryOrder> InventoryOrders { get; set; }
    }
}
