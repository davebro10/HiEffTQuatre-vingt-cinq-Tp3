﻿using Newtonsoft.Json;
using serveur.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace client.API
{
    public class FichierAPI : API
    {
        public async Task<Fichier> GetFileById(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(BaseAddress + "api/fichier/getfile/" + id))
                {
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsAsync<Fichier>();
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task CreateFileAsync(Fichier f)
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
                    response = await client.PostAsync(BaseAddress + "api/fichier/createfile", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public async Task ModifyFileAsync(Fichier f)
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
                    response = await client.PostAsync(BaseAddress + "api/fichier/modifyfile", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public async Task DeleteFileAsync(Fichier f)
        {
            HttpResponseMessage response = null;
            try
            {
                using (HttpClient client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(BaseAddress + "api/client/deletefile");
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
