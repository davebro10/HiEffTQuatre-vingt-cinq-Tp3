using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serveur.Models
{
    public class Client
    {
        [Key]
        public int id_client { get; set; }

        [StringLength(45)]
        public string nom { get; set; }

        [StringLength(45)]
        public string usager { get; set; }

        [StringLength(45)]
        public string motdepasse { get; set; }

        public DateTime? action { get; set; }

        public Client()
        {

        }
    }
}
