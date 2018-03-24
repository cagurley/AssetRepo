using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class ProjectAssetViewModel
    {
        [Required(ErrorMessage = "Project is required.")]
        public int? ProjectId { get; set; }
        
        public string Title { get; set; }

        public ProjectCategoryViewModel Category { get; set; }

        public ContributorViewModel Creator { get; set; }

        public DateTime CreationDateTime { get; set; }

        public ContributorViewModel LastUpdater { get; set; }

        public DateTime LastUpdateDateTime { get; set; }
    }
}