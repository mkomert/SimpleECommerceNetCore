using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETic.Areas.Admin.Models
{
    public class RoleUserVm
    {
        [Required]
        [Display(Name ="Kullanıcı")]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Yetki")]
        public string RoleId { get; set; }
    }
}
