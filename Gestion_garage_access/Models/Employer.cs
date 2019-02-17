using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_garage_access.Models
{
    public class Employer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Enmployer { get; set; }
        [Required]
        public string Name { get; set; }
        public string Tel { get; set; }

        public int Id_Entreprise { get; set; }
        public Entreprise Entreprise { get; set; }
        public ICollection<Bon> Bons { get; set; }


    }
}
