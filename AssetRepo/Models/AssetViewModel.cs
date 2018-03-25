using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public ProjectPopulatedViewModel Project { get; set; }

        public AssetTypeSubtypePairingViewModel TypeSubtypePairing { get; set; }

        public ContributorPopulatedViewModel Creator { get; set; }

        public DateTime CreationDateTime { get; set; }

        public ContributorPopulatedViewModel LastUpdater { get; set; }

        public DateTime LastUpdateDateTime { get; set; }

        public string Comment { get; set; }

        [Required(ErrorMessage = "File is required."), DisplayName("File")]
        public string FilePlaceholder { get; set; }
    }
}