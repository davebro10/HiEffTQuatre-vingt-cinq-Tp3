using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using serveur.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace client.API
{
    class ClientAPI : API
    {
        public async Task<List<Client>> getAllClients() {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseAddress + "api/client/getallclient/").Result;
            if (response.IsSuccessStatusCode) {
                List<Client> clients = await response.Content.ReadAsAsync<List<Client>>();
                return clients;
            }
            return null;
        }

        public async Task<Client> getClientById(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseAddress + "api/client/getclient/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Client c = await response.Content.ReadAsAsync<Client>();
                return c;
            }
            return null;
        }

        public async Task<Client> auth(Client c)
        {
            HttpClient client = new HttpClient();
            string jsonClient = JsonConvert.SerializeObject(c);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonClient);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync(baseAddress + "api/client/auth/", byteContent).Result;
            if (response.IsSuccessStatusCode)
            {
                Client authClient = await response.Content.ReadAsAsync<Client>();
                return authClient;
            }
            return null;
        }

        public void createClient(Client newClient) {
            Client c = new Client();
            c.nom = newClient.nom;
            c.usager = newClient.usager;
            c.motdepasse = newClient.motdepasse;
            c.action = DateTime.Now;

            HttpClient client = new HttpClient();
            var jsonObj = JsonConvert.SerializeObject(c);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = client.PostAsync(baseAddress + "api/client/createclient", byteContent).Result;
        }
    }
}
