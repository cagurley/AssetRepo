using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class ProjectCategory
    {
        public int ProjectCategoryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}