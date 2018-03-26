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
        [Required, StringLength(200)]
        public string Title { get; set; }
        public int ProjectCategoryId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LastUpdaterId { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        [Required, StringLength(2000)]
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public virtual ProjectCategory ProjectCategory { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual Contributor Creator { get; set; }
        public virtual Contributor LastUpdater { get; set; }
    }
}