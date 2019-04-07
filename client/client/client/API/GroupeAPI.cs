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
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(baseAddress + "api/groupe/getallgroup"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<List<Groupe>>();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return new List<Groupe>();
        }
        public async Task<Groupe> getGroupById(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(baseAddress + "api/groupe/getgroup/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<Groupe>();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task createGroup(string name, int admin_id)
        {
            Groupe g = new Groupe();
            g.nom = name;
            g.admin = admin_id;
            var jsonObj = JsonConvert.SerializeObject(g);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            HttpResponseMessage response = null;

            try
            {
                using (HttpClient client = new HttpClient())
                using (var byteContent = new ByteArrayContent(buffer))
                {
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(baseAddress + "api/client/creategroup", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public async Task modifyGroupAsync(Groupe g)
        {
            var jsonObj = JsonConvert.SerializeObject(g);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            HttpResponseMessage response = null;

            try
            {
                using (HttpClient client = new HttpClient())
                using (var byteContent = new ByteArrayContent(buffer))
                {
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(baseAddress + "api/groupe/modifygroup", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            response?.Dispose();
        }

        public async Task deleteGroupAsync(Groupe g)
        {
            HttpResponseMessage response = null;
            try
            {
                using (HttpClient client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {

                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(baseAddress + "api/groupe/deletegroup");
                    request.Content = new StringContent(JsonConvert.SerializeObject(g), System.Text.Encoding.UTF8, "application/json");

                    response = await client.SendAsync(request);
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
