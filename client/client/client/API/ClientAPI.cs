using Newtonsoft.Json;
using serveur.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace client.API
{
    public class ClientAPI : API
    {
        public async Task<List<Client>> GetAllClients()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(BaseAddress + "api/client/getallclient/"))
                {
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsAsync<List<Client>>();
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return new List<Client>();
        }

        public async Task<Client> GetClientById(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(BaseAddress + "api/client/getclient/" + id))
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

        public async Task<Client> GetClientByUser(string user)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(BaseAddress + "api/client/getclient?usager=" + user))
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

        public async Task<Client> Auth(Client c)
        {
            try
            {
                string jsonClient = JsonConvert.SerializeObject(c);
                var buffer = System.Text.Encoding.UTF8.GetBytes(jsonClient);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.PostAsync(BaseAddress + "api/client/auth/", byteContent))
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

        public async Task CreateClientAsync(Client newClient)
        {
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
                    response = await client.PostAsync(BaseAddress + "api/client/createclient", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public async Task ModifyClientAsync(Client clientToModify)
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
                    response = await client.PostAsync(BaseAddress + "api/client/modifyclient", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public void DeleteClient(Client clientToDelete)
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
                    request.RequestUri = new Uri(BaseAddress + "api/client/deleteclient");
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
