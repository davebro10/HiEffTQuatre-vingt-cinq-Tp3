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
            List<Client> lstc = new List<Client>();

            API api = new API();
            lstc = api.GetAllClient();

            return lstc;
        }

        [HttpPost]
        // POST api/client/createclient
        public bool CreateClient(Client c)
        {
            API api = new API();
            return api.CreateClient(c);
        }

        [HttpPost]
        // POST api/client/modifyclient
        public bool ModifyClient(Client c)
        {
            API api = new API();
            return api.ModifyClient(c);
        }

        [HttpPost]
        // POST api/client/auth
        public Client Auth(Client c)
        {
            API api = new API();
            return api.Authentificate(c.usager,c.motdepasse);
        }

        [HttpDelete]
        // DELETE api/client/deleteclient
        public bool DeleteClient(Client c)
        {
            API api = new API();
            return api.DeleteClient(c);
        }

        [HttpGet]
        // GET api/client/getclient/{id}
        public Client GetClient(int id)
        {
            API api = new API();
            Client c = api.GetClient(id);

            return c;
        }

        [HttpGet]
        // GET api/client/getclient?usager=
        public Client GetClient([FromUri]string usager)
        {
            API api = new API();
            Client c = api.GetClient(usager);

            return c;
        }

    }
}

