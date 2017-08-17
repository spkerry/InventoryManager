using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels
{
    public class AddVendorViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Contact { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name="Phone Number")]
        [DisplayFormat(DataFormatString = "{0:###-###-####")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
