using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class AssetTypeSubtypePairingViewModel
    {
        [Required(ErrorMessage = "Type and subtype are required."), DisplayName("Type/Subtype")]
        public int? AssetTypeSubtypePairingId { get; set; }

        public AssetTypeViewModel Type { get; set; }

        public AssetSubtypeViewModel Subtype { get; set; }

        public string DisplayPairing => Type.Name + ": " + Subtype.Name;
    }
}