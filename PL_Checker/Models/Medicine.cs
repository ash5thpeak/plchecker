using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Runtime.CompilerServices;

namespace PL_Checker.Models
{
    // NB: Models can be auto-generated from existing SQL Contexts

    public class Medicine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Medicine Name")]
        [Required(ErrorMessage = "Medicine Name is required 1"), StringLength(100, MinimumLength = 3)]
        [DisplayFormat(NullDisplayText = "Medicine Name is required 1")]
        public string? Name { get; set; }

        [Display(Name = "PL Number")]
        [StringLength(20)]
        public string? PL_Number { get; set; }

        [Display(Name = "Image URL")]
        [StringLength(255)]
        public string? ImageUrl { get; set; }

        // Foreign Key: ICollection - EFCore creates a HashSet
        public ICollection<MedicineAttribution>? MedicineAttributions { get; set; }
    }
}

