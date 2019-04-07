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
            HttpResponseMessage response = await client.GetAsync(baseAddress + "api/groupe/getallgroup");
            if (response.IsSuccessStatusCode)
            {
                List<Groupe> groups = await response.Content.ReadAsAsync<List<Groupe>>();
                return groups;
            }
            return null;
        }
        public async Task<Groupe> getGroupById(int id) {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(baseAddress + "api/groupe/getgroup/" + id);
            if (response.IsSuccessStatusCode)
            {
                Groupe group = await response.Content.ReadAsAsync<Groupe>();
                return group;
            }
            return null;
        }

        public async Task createGroup(string name, int admin_id)
        {
            Groupe g = new Groupe();
            g.nom = name;
            g.admin = admin_id;

            HttpClient client = new HttpClient();
            var jsonObj = JsonConvert.SerializeObject(g);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync(baseAddress + "api/client/creategroup", byteContent);
        }

        public void modifyGroup(Groupe g)
        {
            HttpClient client = new HttpClient();
            var jsonObj = JsonConvert.SerializeObject(g);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = client.PostAsync(baseAddress + "api/groupe/modifygroup", byteContent).Result;
        }

        public void deleteGroup(Groupe g)
        {
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(baseAddress + "api/groupe/deletegroup"),
                Content = new StringContent(JsonConvert.SerializeObject(g), System.Text.Encoding.UTF8, "application/json")
            };
            var response = client.SendAsync(request).Result;
        }
    }
}
