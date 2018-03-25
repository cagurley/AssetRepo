using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class ContributorViewModel
    {
        public int? ContributorId { get; set; }

        [Required(ErrorMessage = "Name is required."), StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }
    }
}