using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    public class Order : Inventory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReceivedDate { get; set; }

        public IList<Inventory> Inventory { get; set; }
    }
}
