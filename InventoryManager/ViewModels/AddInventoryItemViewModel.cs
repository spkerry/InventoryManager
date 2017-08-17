using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InventoryManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManager.ViewModels
{
    public class AddInventoryItemViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Upc { get; set; }

        public float Cost { get; set; }

        public float Quantity { get; set; }

        public string Unit { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name="Vendor")]
        public int VendorID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public List<SelectListItem> Vendors { get; set; }

        public AddInventoryItemViewModel() { }

        public AddInventoryItemViewModel(IEnumerable<InventoryCategory> categories, IEnumerable<Vendor> vendors)
        {
            Categories = new List<SelectListItem>();
            Vendors = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name
                });
            }

            foreach (var vendor in vendors)
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
