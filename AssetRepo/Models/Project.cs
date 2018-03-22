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
        public int ProjectCategoryId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LastContributionId { get; set; }
        public DateTime LastContributionDateTime { get; set; }

        public virtual ProjectCategory ProjectCategory { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }
}