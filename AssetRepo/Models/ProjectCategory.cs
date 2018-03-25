using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class ProjectCategory
    {
        public int ProjectCategoryId { get; set; }
        [Required, StringLength(50), Index(IsUnique = true)]
        public string Name { get; set; }
    }
}