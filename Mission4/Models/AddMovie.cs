using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    //Model for adding movies to the database
    public class AddMovie
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        //Build foreign Key Relationship
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Movie Title Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year Required")]
        public short Year { get; set; }

        [Required(ErrorMessage ="Director Name Required")]
        public string Director { get; set; }

        [Required(ErrorMessage ="Movie Rating Required")]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }
    }
}
