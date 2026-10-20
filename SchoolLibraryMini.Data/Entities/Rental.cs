using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibraryMini.Data.Entities
{
    internal class Rental
    {
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }

        [ForeignKey("Viewer")]
        public Guid ViewerId { get; set; }

        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Movie Movie { get; set; } = null!;
        public Viewer Viewer { get; set; } = null!;
    }
}
