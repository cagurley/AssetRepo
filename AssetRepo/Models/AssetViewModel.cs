using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class AssetViewModel
    {
        public int? AssetId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        public ProjectViewModel Project { get; set; }

        public AssetTypeViewModel Type { get; set; }

        public AssetSubtypeViewModel Subtype { get; set; }

        public ContributorViewModel Creator { get; set; }

        public DateTime CreationDateTime { get; set; }

        public ContributorViewModel LastUpdater { get; set; }

        public DateTime LastUpdateDateTime { get; set; }

        public string Comment { get; set; }
    }
}