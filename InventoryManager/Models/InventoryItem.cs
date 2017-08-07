using System;

namespace InventoryManager.Models
{
    public class InventoryItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public float Quantity { get; set; }
        public string Upc { get; set; }
        public DateTime DateAdded { get; set; }
        public float Usage { get; set; }
        public DateTime DateModified { get; set; }

        public int CategoryID { get; set; }
        public InventoryCategory Category { get; set; }

        public int VendorID { get; set; }
        public Vendor Vendor { get; set; }

    }
}
