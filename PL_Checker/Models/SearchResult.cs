using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PL_Checker.Models
{
    public class SearchResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name ="Search Term")]
        public string? SearchTerm { get; set; }

        public int? Rating { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Search Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime SearchDate { get; set; }
    }
}

