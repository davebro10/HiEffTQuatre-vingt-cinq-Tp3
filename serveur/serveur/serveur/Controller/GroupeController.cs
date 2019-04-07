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
             return new API().GetAllGroup();
        }

        [HttpPost]
        // POST api/groupe/creategroup
        public bool CreateGroup(Groupe g)
        {
            return new API().CreateGroup(g);
        }

        [HttpPost]
        // POST api/groupe/modifygroup
        public bool ModifyGroup(Groupe g)
        {
            return new API().ModifyGroup(g);
        }

        [HttpDelete]
        // POST api/groupe/deletegroup
        public bool DeleteGroup(Groupe g)
        {
            return new API().DeleteGroup(g);
        }

        [HttpGet]
        // GET api/groupe/getgroup/{id}
        public Groupe GetGroup(int id)
        {
            return new API().GetGroup(id);
        }
    }
}

