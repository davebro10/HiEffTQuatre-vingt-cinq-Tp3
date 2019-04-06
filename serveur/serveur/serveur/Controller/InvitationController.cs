using serveur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace serveur
{
    public class InvitationController : ApiController
    {

        // GET api/invitation/getallinvitation
        public List<Invitation> GetAllInvitation()
        {
            List<Invitation> lsti = new List<Invitation>();

            API api = new API();
            lsti = api.GetAllInvitation();

            return lsti;
        }

        [HttpGet]
        // GET api/invitation/getinvitationbyclient/{id}
        public List<Invitation> GetInvitationByClient(int id)
        {
            API api = new API();
            List<Invitation> listi = api.GetInvitationByClient(id);

            return listi;
        }

        [HttpGet]
        // GET api/invitation/GetGroupMember?id_groupe={id}
        public List<Client> GetGroupMember([FromUri]int id_groupe)
        {
            API api = new API();
            List<Client> listc = api.GetGroupMember(id_groupe);

            return listc;
        }

        [HttpPost]
        // POST api/invitation/InviteMemberToGroup
        public bool InviteMemberToGroup([FromBody]Invitation inv)
        {
            API api = new API();
            return api.InviteMemberToGroup(inv.id_groupe_fk,inv.id_client_fk);
        }

        [HttpDelete]
        // DELETE api/invitation/RemoveMemberFromGroup
        public bool RemoveMemberFromGroup([FromBody]Invitation inv)
        {
            API api = new API();
            return api.RemoveMemberFromGroup(inv.id_groupe_fk,inv.id_client_fk);
        }

        [HttpPost]
        // POST api/invitation/InviteAnswer
        public bool InviteAnswer([FromBody]Invitation inv)
        {
            API api = new API();
            return api.InviteAnswer(inv.id_invitation,inv.answer);
        }
    }
}

