using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    public class InventoryCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<InventoryItem> Items { get; set; }
    }
}
