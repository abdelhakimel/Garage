using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_garage_access.Models
{
    public class SaleClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_sale { get; set; }
        [Required]
        public double Number { get; set; }
        [Required]
        public Piece Piece { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
