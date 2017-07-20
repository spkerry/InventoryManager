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
        

    }
}
