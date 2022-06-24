using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class BodyKit
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field 'FrontBumper' is required")]
        public string FrontBumper { get; set; }


        [Required(ErrorMessage = "Field 'RearBumper' is required")]
        [MaxLength(20)]
        [MinLength(2)]
        public string RearBumper { get; set; }


        [Required(ErrorMessage = "Field 'SideSkirts' is required")]
        public string SideSkirts { get; set; }

        [Required(ErrorMessage = "Field 'Version' is required")]
        [Range(0.0d, 100.0d)]
        public double Vrsion { get; set; }
    }
}
