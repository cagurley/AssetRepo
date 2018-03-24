using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class ProjectCategoryViewModel
    {
        [Required(ErrorMessage = "Category is required."), DisplayName("Category")]
        public int? ProjectCategoryId { get; set; }
        
        public string Name { get; set; }
    }
}