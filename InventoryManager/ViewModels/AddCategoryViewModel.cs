using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventoryManager.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
