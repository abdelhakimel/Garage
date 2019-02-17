using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_garage_access.Models
{
    public class Bon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Bon { get; set; }
        [Required]
        public double TotalePrix { get; set; }
        [Required]
        public double FirstPrix { get; set; }
        [Required]
        public double RestPrix { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Id_Enmployer { get; set; }
        public Employer Employer { get; set; }
    }
}
