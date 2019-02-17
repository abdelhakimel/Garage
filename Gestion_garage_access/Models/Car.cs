using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_garage_access.Models
{
    public class Car
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_car { get; set; }
        [Required]
        public string Nom_car { get; set; }
        public  ICollection<Module> Modules_car { get; set; }

    
    }
}
