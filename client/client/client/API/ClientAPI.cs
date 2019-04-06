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
            HttpResponseMessage response = client.GetAsync(baseAddress + "api/client/getallclient").Result;
            if (response.IsSuccessStatusCode) {
                List<Client> clients = await response.Content.ReadAsAsync<List<Client>>();
                return clients;
            }
            return null;
        }

        public void createClient() {
            Client c = new Client();
            c.nom = "test1";
            c.usager = "test2";
            c.motdepasse = "test3";
            c.action = DateTime.Now;

            HttpClient client = new HttpClient();
            var jsonObj = JsonConvert.SerializeObject(c);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = client.PostAsync(baseAddress + "api/client/createclient", byteContent).Result;

            Console.WriteLine(response);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
    }
}
