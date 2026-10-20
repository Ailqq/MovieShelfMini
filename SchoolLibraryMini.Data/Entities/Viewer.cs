using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibraryMini.Data.Entities
{
    internal class Viewer
    {
        [Key]
        public Guid ViewerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
