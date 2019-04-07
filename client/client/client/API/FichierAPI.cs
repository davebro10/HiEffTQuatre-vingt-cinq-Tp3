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
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseAddress + "api/fichier/getfile/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Fichier fichier = await response.Content.ReadAsAsync<Fichier>();
                return fichier;
            }
            return null;
        }

        public void createFile(Fichier f)
        {
            HttpClient client = new HttpClient();
            var jsonObj = JsonConvert.SerializeObject(f);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = client.PostAsync(baseAddress + "api/fichier/createfile", byteContent).Result;
        }

        public void modifyFile(Fichier f)
        {
            HttpClient client = new HttpClient();
            var jsonObj = JsonConvert.SerializeObject(f);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = client.PostAsync(baseAddress + "api/fichier/modifyfile", byteContent).Result;
        }

        public void deleteFile(Fichier f)
        {
            HttpClient client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(baseAddress + "api/client/deletefile"),
                Content = new StringContent(JsonConvert.SerializeObject(f), System.Text.Encoding.UTF8, "application/json")
            };
            var response = client.SendAsync(request).Result;
        }
    }
}
