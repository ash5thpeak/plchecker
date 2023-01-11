using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PL_Checker.Models
{
    public class MedicineAttribution
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Medicine ID")]
        [Required]
        public int MedicineId { get; set; }

        [Display(Name = "Location ID")]
        public int? LocationId { get; set; }

        [Display(Name = "Price")]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        // Foreign Key: ICollection - EFCore creates a HashSet
        public ICollection<Location>? Locations { get; set; }
        public ICollection<Medicine>? Medicines { get; set; }

    }
}

