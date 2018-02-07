using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JacHomePage.Models
{
    public class Offer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
