using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie1.Models
{
    public class Movie
    {
        public int ID { get; set; }
       // [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
     //   [Required]
        public string Genre { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Comment { get; set; }
    }

    
}
