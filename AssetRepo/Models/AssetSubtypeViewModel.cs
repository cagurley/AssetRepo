using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class AssetSubtypeViewModel
    {
        [Required(ErrorMessage = "Subtype is required."), DisplayName("Subtype")]
        public int? AssetSubtypeId { get; set; }

        public string Name { get; set; }
    }
}