using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibraryMini.Data.Entities
{
    internal class Movie
    {
        [Key]
        public Guid MovieId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [ForeignKey("Director")]
        public Guid DirectorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Genre { get; set; } = string.Empty;

        [Required]
        public int Year { get; set; }

        [Required]
        public int Duration { get; set; }

        
        public Director Director { get; set; } = null!;

        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}

