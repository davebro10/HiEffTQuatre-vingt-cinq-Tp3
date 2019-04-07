using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using serveur.Models;
using Newtonsoft.Json;

namespace client.API
{
    class FichierAPI : API
    {
        public async Task<Fichier> getFileById(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(baseAddress + "api/fichier/getfile/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<Fichier>();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task createFileAsync(Fichier f)
        {
            var jsonObj = JsonConvert.SerializeObject(f);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            HttpResponseMessage response = null;

            try
            {
                using (HttpClient client = new HttpClient())
                using (var byteContent = new ByteArrayContent(buffer))
                {
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(baseAddress + "api/fichier/createfile", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public async Task modifyFileAsync(Fichier f)
        {
            var jsonObj = JsonConvert.SerializeObject(f);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            HttpResponseMessage response = null;
            try
            {
                using (HttpClient client = new HttpClient())
                using (var byteContent = new ByteArrayContent(buffer))
                {
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(baseAddress + "api/fichier/modifyfile", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public async Task deleteFileAsync(Fichier f)
        {
            HttpResponseMessage response = null;
            try
            {
                using (HttpClient client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(baseAddress + "api/client/deletefile");
                    request.Content = new StringContent(JsonConvert.SerializeObject(f), System.Text.Encoding.UTF8, "application/json");

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
