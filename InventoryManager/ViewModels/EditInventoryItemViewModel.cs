using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InventoryManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManager.ViewModels
{
    public class EditInventoryItemViewModel
    {
        public string Name { get; set; }
        public string Upc { get; set; }
        public float Cost { get; set; }
        public string Unit { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Vendor")]
        public int VendorID { get; set; }

        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Vendors { get; set; }
        public InventoryItem Item { get; set; }

        public EditInventoryItemViewModel() { }

        public EditInventoryItemViewModel(InventoryItem item, IEnumerable<InventoryCategory> categories, IEnumerable<Vendor> vendors)
        {
            Item = new InventoryItem
            {
                Name = item.Name,
                Upc = item.Upc,
                Cost = item.Cost,
                Unit = item.Unit,
                DateAdded = item.DateAdded,
                DateModified = item.DateModified
            };

            Categories = new List<SelectListItem>();
            Vendors = new List<SelectListItem>();

            foreach(var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name
                });
            }

            foreach( var vendor in vendors)
            {
                Vendors.Add(new SelectListItem
                {
                    Value = vendor.ID.ToString(),
                    Text = vendor.Name
                });
            }
        }
    }
}
