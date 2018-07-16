using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie1.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage ="Passwords does not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat your password")]
        public string ConfirmPassword { get; set; }

        //public ICollection<Movie> Movies;


    }


}
