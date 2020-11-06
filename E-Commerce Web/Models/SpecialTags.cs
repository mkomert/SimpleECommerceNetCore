﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETic.Models
{
    public class SpecialTags
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Etiket Adı")]
        public string SpecialTag { get; set; }
    }
}
