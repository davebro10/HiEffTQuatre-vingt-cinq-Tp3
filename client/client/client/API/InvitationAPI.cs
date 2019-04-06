using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using serveur.Models;
using Newtonsoft.Json;

namespace client.API
{
    class InvitationAPI : API
    {
        public async Task<List<Invitation>> getAllGroups()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseAddress + "api/groupe/getallinvitation").Result;
            if (response.IsSuccessStatusCode)
            {
                List<Invitation> invites = await response.Content.ReadAsAsync<List<Invitation>>();
                return invites;
            }
            return null;
        }

        public async Task<List<Client>> getGroupMembers(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseAddress + "api/invitation/GetGroupMember?id_groupe=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                List<Client> clients = await response.Content.ReadAsAsync<List<Client>>();
                return clients;
            }
            return null;
        }
    }
}
