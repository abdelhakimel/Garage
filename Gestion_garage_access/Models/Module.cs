using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_garage_access.Models
{
    public class Module
    {
        [Key]
        public string Nom_mod { get; set; }
    }
}
