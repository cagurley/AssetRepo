using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class Asset
    {
        public int AssetId { get; set; }
        [Required]
        public string Title { get; set; }
        public int TypeId { get; set; }
        public int SubtypeId { get; set; }
        public int ContributorId { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public string Comment { get; set; }

        public virtual AssetType Type { get; set; }
        public virtual AssetSubtype Subtype { get; set; }
        public virtual Contributor Contributor { get; set; }
    }
}