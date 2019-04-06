using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serveur.Models
{
    public class Invitation
    {
        [Key]
        public int id_invitation { get; set; }

        public int id_groupe_fk { get; set; }

        public int id_client_fk { get; set; }

        public bool answer { get; set; }

        public Invitation()
        {

        }
    }
}
