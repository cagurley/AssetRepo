using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Category { get; set; }
        public string CreatorId { get; set; }
        public string AssetId { get; set; }
        public DateTime LastContributionDateTime { get; set; }

        public virtual Contributor Creator { get; set; }
        public virtual Asset LastContribution { get; set; }
    }
}