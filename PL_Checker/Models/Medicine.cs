using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace PL_Checker.Models
{
    // NB: Models can be auto-generated from existing SQL Contexts

    public class Medicine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Medicine Name is required 1"), StringLength(100)]
        [DisplayFormat(NullDisplayText = "Medicine Name is required 1")]
        public string? Name { get; set; }

        [StringLength(20)]
        public string? PL_Number { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        // Foreign Key: ICollection - EFCore creates a HashSet
        //public ICollection<> { get; set; }
    }
}

