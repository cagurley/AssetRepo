using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class ProjectViewModel
    {
        public int? ProjectId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Category { get; set; }

        public ContributorViewModel Creator { get; set; }

        public AssetViewModel LastContribution { get; set; }

        public DateTime LastContributionDateTime { get; set; }
    }
}