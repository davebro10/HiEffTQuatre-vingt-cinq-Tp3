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
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(baseAddress + "api/client/getallclient/"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<List<Client>>();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return new List<Client>();
        }

        public async Task<Client> getClientById(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(baseAddress + "api/client/getclient/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<Client>();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Client> getClientByUser(string user)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(baseAddress + "api/client/getclient?usager=" + user))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<Client>();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Client> auth(Client c)
        {
            try
            {
                string jsonClient = JsonConvert.SerializeObject(c);
                var buffer = System.Text.Encoding.UTF8.GetBytes(jsonClient);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.PostAsync(baseAddress + "api/client/auth/", byteContent))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        Client authClient = await response.Content.ReadAsAsync<Client>();
                        return authClient;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task createClientAsync(Client newClient) {
            Client c = new Client();
            c.nom = newClient.nom;
            c.usager = newClient.usager;
            c.motdepasse = newClient.motdepasse;
            c.action = DateTime.Now;
            var jsonObj = JsonConvert.SerializeObject(c);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            HttpResponseMessage response = null;

            try
            {
                using (HttpClient client = new HttpClient())
                using(var byteContent = new ByteArrayContent(buffer))
                {
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(baseAddress + "api/client/createclient", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public async Task modifyClientAsync(Client clientToModify)
        {
            Client c = new Client();
            c.id_client = clientToModify.id_client;
            c.nom = clientToModify.nom;
            c.usager = clientToModify.usager;
            c.motdepasse = clientToModify.motdepasse;
            c.action = DateTime.Now;
            var jsonObj = JsonConvert.SerializeObject(c);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            HttpResponseMessage response = null;

            try
            {
                using (HttpClient client = new HttpClient())
                using (var byteContent = new ByteArrayContent(buffer))
                {
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(baseAddress + "api/client/modifyclient", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public void deleteClient(Client clientToDelete)
        {
            Client c = new Client();
            c.id_client = clientToDelete.id_client;
            c.nom = clientToDelete.nom;
            c.usager = clientToDelete.usager;
            c.motdepasse = clientToDelete.motdepasse;
            c.action = DateTime.Now;
            HttpResponseMessage response = null;
            try
            {
                using (HttpClient client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(baseAddress + "api/client/deleteclient");
                    request.Content = new StringContent(JsonConvert.SerializeObject(c), System.Text.Encoding.UTF8, "application/json");

                    response = client.SendAsync(request).Result;
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }
    }
}
