using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionnaireDonation.Models
{
    public class DonationModel
    {
        [Key]
        public int DonationId { get; set; }

        
        [Required(ErrorMessage ="Champs requis.")]
        [DisplayName("Code Donation")]
        [Column(TypeName="nvarchar(24)")]
        public string DonationCode { get; set; }


        [Required(ErrorMessage = "Champs requis.")]
        [DisplayName("Nom Donateur")]
        [Column(TypeName = "nvarchar(24)")]
        public string DonateurNom { get; set; }

        [Required(ErrorMessage = "Champs requis.")]
        [DisplayName("Nom Banque")]
        [Column(TypeName = "nvarchar(100)")]
        public string BanqueNom { get; set; }


        [Required(ErrorMessage = "Champs requis.")]
        [DisplayName("RIB")]
        [Column(TypeName = "nvarchar(24)")]
        public string RIBCode { get; set; }

        public int Montant { get; set; }

        
        public DateTime Date { get; set; }
    }
}
