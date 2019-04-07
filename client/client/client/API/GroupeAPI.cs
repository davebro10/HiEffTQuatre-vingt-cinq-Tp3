using Newtonsoft.Json;
using serveur.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace client.API
{
    public class GroupeAPI : API
    {
        public async Task<List<Groupe>> GetAllGroups()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(BaseAddress + "api/groupe/getallgroup"))
                {
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsAsync<List<Groupe>>();
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return new List<Groupe>();
        }

        public async Task<Groupe> GetGroupById(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(BaseAddress + "api/groupe/getgroup/" + id))
                {
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsAsync<Groupe>();
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task CreateGroup(string name, int adminId)
        {
            Groupe g = new Groupe();
            g.nom = name;
            g.admin = adminId;
            var jsonObj = JsonConvert.SerializeObject(g);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            HttpResponseMessage response = null;

            try
            {
                using (HttpClient client = new HttpClient())
                using (var byteContent = new ByteArrayContent(buffer))
                {
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(BaseAddress + "api/groupe/creategroup", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public async Task ModifyGroupAsync(Groupe g)
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
                    response = await client.PostAsync(BaseAddress + "api/groupe/modifygroup", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            response?.Dispose();
        }

        public async Task DeleteGroupAsync(Groupe g)
        {
            HttpResponseMessage response = null;
            try
            {
                using (HttpClient client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {

                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(BaseAddress + "api/groupe/deletegroup");
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
