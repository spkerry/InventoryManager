using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    public class VendorOrder
    {
        public int ID { get; set; }
        public int InventoryItemID { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public Vendor Vendor { get; set; }

    }
}
