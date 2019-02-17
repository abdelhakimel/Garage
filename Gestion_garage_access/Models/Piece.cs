using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_garage_access.Models
{
    public class Piece
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_piece { get; set; }
        [StringLength(30)]
        [MinLength(3)]
        [DisplayName("Reference")]
        public string Ref_piece { get; set; }
        [Required]
        [StringLength(30)]
        [MinLength(3)]
        [DisplayName("Nom ")]
        public string Nom_piece { get; set; }
        [Required]
        [Range(typeof(double), "0", "79228162514264337593543950335")]
        [DisplayName("Prix d'achat")]
        public double Prix_achat { get; set; }
        [Required]
        [Range(typeof(double), "0", "79228162514264337593543950335")]
        [DisplayName( "Prix de Vente")]
        public double Prix_vente { get; set; }
        [Required]
        [DisplayName( "Les automobiles")]
        public string  Cars { get; set; }
        [DisplayName( "Quantite")]
        [Required]
        [Range(typeof(double), "0", "79228162514264337593543950335")]
        public double Quantite { get; set; }
        [DisplayName( "Unité de mesure")]
        [Required]
        public string Unite { get; set; }
        [Required]
        public string Qualite { get; set; }
    }
}
