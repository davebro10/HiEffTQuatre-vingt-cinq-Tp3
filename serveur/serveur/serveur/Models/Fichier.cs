using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serveur.Models
{
    public class Fichier
    {
        [Key]
        public int id_fichier { get; set; }

        public int id_groupe_fk { get; set; }

        [StringLength(45)]
        public string nom { get; set; }

        public Fichier()
        {

        }
    }
}
