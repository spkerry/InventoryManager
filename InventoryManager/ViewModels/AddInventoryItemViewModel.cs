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

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddInventoryItemViewModel() { }

        public AddInventoryItemViewModel(IEnumerable<InventoryCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name
                });
            }
        }
    }
}
