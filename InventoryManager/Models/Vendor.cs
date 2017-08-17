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
        public DateTime DateAdded { get; set; }
        public string Contact { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public IList<InventoryItem> Items { get; set; }
    }
}
