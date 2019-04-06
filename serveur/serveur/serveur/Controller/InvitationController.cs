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
        // POST api/invitation/InviteMemberToGroup?id_groupe={id}&id_client={id}
        public bool InviteMemberToGroup([FromUri]int id_groupe,[FromUri]int id_client)
        {
            API api = new API();
            return api.InviteMemberToGroup(id_groupe,id_client);
        }

        [HttpPost]
        // POST api/invitation/RemoveMemberFromGroup?id_groupe={id}&id_client={id}
        public bool RemoveMemberFromGroup([FromUri]int id_groupe,[FromUri]int id_client)
        {
            API api = new API();
            return api.RemoveMemberFromGroup(id_groupe,id_client);
        }

        [HttpPost]
        // POST api/invitation/InviteAnswer?id_invitation={id}&answer={bool}
        public bool InviteAnswer(int id_invitation, bool answer)
        {
            API api = new API();
            return api.InviteAnswer(id_invitation,answer);
        }
    }
}

