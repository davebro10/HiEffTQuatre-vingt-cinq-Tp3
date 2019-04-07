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
            return new API().GetAllInvitation();
        }

        [HttpGet]
        // GET api/invitation/getinvitationbyclient/{id}
        public List<Invitation> GetInvitationByClient(int id)
        {
            return new API().GetInvitationByClient(id);
        }

        [HttpGet]
        // GET api/invitation/GetGroupMember?id_groupe={id}
        public List<Client> GetGroupMember([FromUri]int id_groupe)
        {
            return new API().GetGroupMember(id_groupe);
        }

        [HttpPost]
        // POST api/invitation/InviteMemberToGroup
        public bool InviteMemberToGroup([FromBody]Invitation inv)
        {
            return new API().InviteMemberToGroup(inv.id_groupe_fk,inv.id_client_fk);
        }

        [HttpDelete]
        // DELETE api/invitation/RemoveMemberFromGroup
        public bool RemoveMemberFromGroup([FromBody]Invitation inv)
        {
            return new API().RemoveMemberFromGroup(inv.id_groupe_fk,inv.id_client_fk);
        }

        [HttpPost]
        // POST api/invitation/InviteAnswer
        public bool InviteAnswer([FromBody]Invitation inv)
        {
            return new API().InviteAnswer(inv.id_invitation,inv.answer);
        }
    }
}

