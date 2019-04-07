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
        public async Task<Groupe> getGroupById(int id) {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseAddress + "api/groupe/getgroup/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Groupe group = await response.Content.ReadAsAsync<Groupe>();
                return group;
            }
            return null;
        }

        public void createGroup(string name, int admin_id)
        {
            Groupe g = new Groupe();
            g.nom = name;
            g.admin = admin_id;

            HttpClient client = new HttpClient();
            var jsonObj = JsonConvert.SerializeObject(g);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = client.PostAsync(baseAddress + "api/client/creategroup", byteContent).Result;
        }
    }
}
