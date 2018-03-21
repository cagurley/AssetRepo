using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class ContributorViewModel
    {
        public int? ContributorId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}