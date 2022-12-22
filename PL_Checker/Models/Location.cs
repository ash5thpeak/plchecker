using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PL_Checker.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Location Name")]
        [Required(ErrorMessage = "Location Name is required 1"), StringLength(100, MinimumLength = 3)]
        [DisplayFormat(NullDisplayText = "Location Name is required 1")]
        public string? Name { get; set; }

        public string? Latitude { get; set; }

        public string? Longitude { get; set; }

        [StringLength(12)]
        public string? Postcode { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}

