using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        public float TotalUsage { get; set; }
        public float TempUsage { get; set; }
        public DateTime DateModified { get; set; }
        public string Unit { get; set; }

        [ForeignKey("InventoryCatagory")]
        public int CategoryID { get; set; }
        public InventoryCategory Category { get; set; }

        [ForeignKey("Vendor")]
        public int VendorID { get; set; }
        public Vendor Vendor { get; set; }

    }
}
