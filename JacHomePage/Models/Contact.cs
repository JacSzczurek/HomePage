using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JacHomePage.Models
{
    public class Contact
    {
        public int ID { get; set; }

        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "Pole nazwa jest wymagane.")]
        [StringLength(255, ErrorMessage = "Przekroczono maksymalną ilość znaków.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole e-mail jest wymagane.")]
        [EmailAddress(ErrorMessage = "Błedny format e-mail.")]
        public string Email { get; set; }

        [DisplayName("Numer telefonu")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Błedny format numeru telefonu")]
        public string PhoneNumber { get; set; }

        [DisplayName("Wiadomość")]
        [StringLength(3500, ErrorMessage = "Przekroczono maksymalną ilość znaków")]
        public string Comment { get; set; }

        public Offer Offer { get; set; }

        public int? OfferId { get; set; }

        public DateTime ContactDate { get; set; }
    }
}
