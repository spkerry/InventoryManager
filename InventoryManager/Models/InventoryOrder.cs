using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    public class InventoryOrder
    {
        public int InventoryID { get; set; }
        public InventoryItem Item { get; set; }
        
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
