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
            HttpResponseMessage response = client.GetAsync(baseAddress + "api/groupe/getallinvittion").Result;
            if (response.IsSuccessStatusCode)
            {
                List<Invitation> invites = await response.Content.ReadAsAsync<List<Invitation>>();
                return invites;
            }
            return null;
        }
    }
}
