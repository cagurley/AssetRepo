using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class ProjectPopulatedViewModel
    {
        [Required(ErrorMessage = "Project is required.")]
        public int? ProjectId { get; set; }
        
        public string Title { get; set; }

        public ProjectCategoryViewModel Category { get; set; }

        public ContributorPopulatedViewModel Creator { get; set; }

        public DateTime CreationDateTime { get; set; }

        public ContributorPopulatedViewModel LastUpdater { get; set; }

        public DateTime LastUpdateDateTime { get; set; }

        public string Description { get; set; }
    }
}