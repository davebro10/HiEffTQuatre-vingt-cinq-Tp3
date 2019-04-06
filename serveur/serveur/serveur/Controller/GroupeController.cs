using serveur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace serveur
{
    public class GroupeController : ApiController
    {

        // GET api/groupe/getallgroup
        public List<Groupe> GetAllGroup()
        {
            List<Groupe> lstc = new List<Groupe>();

            API api = new API();
            lstc = api.GetAllGroup();

            return lstc;
        }

        [HttpPost]
        // POST api/groupe/creategroup
        public bool CreateGroup(Groupe g)
        {
            API api = new API();
            return api.CreateGroup(g);
        }

        [HttpPost]
        // POST api/groupe/modifygroup
        public bool ModifyGroup(Groupe g)
        {
            API api = new API();
            return api.ModifyGroup(g);
        }

        [HttpDelete]
        // POST api/groupe/deletegroup
        public bool DeleteGroup(Groupe g)
        {
            API api = new API();
            return api.DeleteGroup(g);
        }

        [HttpGet]
        // GET api/groupe/getgroup/{id}
        public Groupe GetGroup(int id)
        {
            API api = new API();
            Groupe g = api.GetGroup(id);

            return g;
        }
    }
}

