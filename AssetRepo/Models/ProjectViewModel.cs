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

        [Required(ErrorMessage = "Title is required."), StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; }

        public ProjectCategoryViewModel Category { get; set; }

        public ContributorPopulatedViewModel Creator { get; set; }

        public DateTime CreationDateTime { get; set; }

        public ContributorPopulatedViewModel LastUpdater { get; set; }

        public DateTime LastUpdateDateTime { get; set; }

        [Required(ErrorMessage = "Description is required."), StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters.")]
        public string Description { get; set; }
    }
}