﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class ContributorViewModel
    {
        [Required(ErrorMessage = "Contributor is required."), DisplayName("Contributor")]
        public int? ContributorId { get; set; }
        
        public string Name { get; set; }
    }
}