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
        public string Category { get; set; }
        public string Title { get; set; }
        public short Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }
    }
}
