using System;
using System.ComponentModel.DataAnnotations;

namespace F1Test.Models
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Csapatnév")]
        [Required(ErrorMessage = "A {0} kötelező mező!")]
        public string Name { get; set; }

        [Display(Name = "Alapítás éve")]
        [Required(ErrorMessage = "A {0} kötelező mező!")]
        public int FoundationYear { get; set; }

        [Display(Name = "Világbajnoki címek")]
        [Required(ErrorMessage = "A {0} kötelező mező!")]
        public int Titles { get; set; } // number of championship wins

        public bool HasPayed { get; set; } // entry fee payed or not

    }
}
