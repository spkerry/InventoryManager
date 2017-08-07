using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    public class Vendor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public DateTime DateAdded { get; set; }
        public string Unit { get; set; }
        public string Upc { get; set; }

        public IList<InventoryItem> Items { get; set; }
    }
}
