using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JacHomePage.Models;

namespace JacHomePage.Controllers.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLength(255, ErrorMessage = "Przekroczono maksymalną ilość znaków")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole e-mail jest wymagane")]
        [EmailAddress(ErrorMessage = "Błedny format e-mail")]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }


        [StringLength(3500, ErrorMessage = "Przekroczono maksymalną ilość znaków")]
        public string Comment { get; set; }

        public OfferResource OfferResource { get; set; }
    }
}
