using serveur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace serveur
{
    public class FichierController : ApiController
    {
        [HttpPost]
        // POST api/fichier/createfile/{f}
        public bool CreateFile(Fichier f)
        {
            API api = new API();
            return api.CreateFile(f);
        }

        [HttpPost]
        // POST api/fichier/modifyfile/{f}
        public bool ModifyFile(Fichier f)
        {
            API api = new API();
            return api.ModifyFile(f);
        }

        [HttpPost]
        // POST api/fichier/deletefile/{f}
        public bool DeleteFile(Fichier f)
        {
            API api = new API();
            return api.DeleteFile(f);
        }

        [HttpGet]
        // GET api/fichier/getfile/{id}
        public Fichier GetFile(int id)
        {
            API api = new API();
            Fichier f = api.GetFile(id);

            return f;
        }
    }
}

