using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_garage_access.Models
{
   public class Entreprise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Entreprise { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Tel { get; set; }
        public ICollection<Employer> Employers { get; set; }

    }
}
