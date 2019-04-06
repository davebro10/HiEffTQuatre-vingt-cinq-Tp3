using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using serveur.Models;
using Newtonsoft.Json;

namespace client.API
{
    class GroupeAPI : API
    {
        public async Task<List<Groupe>> getAllGroups()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseAddress + "api/groupe/getallgroup").Result;
            if (response.IsSuccessStatusCode)
            {
                List<Groupe> groups = await response.Content.ReadAsAsync<List<Groupe>>();
                return groups;
            }
            return null;
        }
    }
}
