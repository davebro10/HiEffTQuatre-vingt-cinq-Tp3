using serveur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace serveur
{
    public class ClientController : ApiController
    {

        // GET api/client/getallclient
        public List<Client> GetAllClient()
        {
            return new API().GetAllClient(); ;
        }

        [HttpPost]
        // POST api/client/createclient
        public bool CreateClient(Client c)
        {
            return new API().CreateClient(c);
        }

        [HttpPost]
        // POST api/client/modifyclient
        public bool ModifyClient(Client c)
        {
            return new API().ModifyClient(c);
        }

        [HttpPost]
        // POST api/client/auth
        public Client Auth(Client c)
        {
            return new API().Authentificate(c.usager,c.motdepasse);
        }

        [HttpDelete]
        // DELETE api/client/deleteclient
        public bool DeleteClient(Client c)
        {
            return new API().DeleteClient(c);
        }

        [HttpGet]
        // GET api/client/getclient/{id}
        public Client GetClient(int id)
        {
            return new API().GetClient(id);
        }

        [HttpGet]
        // GET api/client/getclient?usager=
        public Client GetClient([FromUri]string usager)
        {
            return new API().GetClient(usager);
        }

    }
}

