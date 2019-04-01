using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serveur.Models
{
    public class Groupe
    {
        [Key]
        public int id_groupe { get; set; }

        public int admin { get; set; }

        [StringLength(45)]
        public string nom { get; set; }

        public Groupe()
        {

        }
    }
}
