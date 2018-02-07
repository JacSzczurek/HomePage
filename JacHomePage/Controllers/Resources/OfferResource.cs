using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JacHomePage.Controllers.Resources
{
    public class OfferResource
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
