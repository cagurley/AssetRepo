using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class ProjectViewModel
    {
        public int? ProjectId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        public ProjectCategoryViewModel Category { get; set; }

        public ContributorViewModel Creator { get; set; }

        public DateTime CreationDateTime { get; set; }

        public ContributorViewModel LastUpdater { get; set; }

        public DateTime LastUpdateDateTime { get; set; }
    }
}