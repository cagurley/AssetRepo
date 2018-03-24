using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class AssetTypeViewModel
    {
        [Required(ErrorMessage = "Type is required."), DisplayName("Type")]
        public int? AssetTypeId { get; set; }

        public string Name { get; set; }
    }
}