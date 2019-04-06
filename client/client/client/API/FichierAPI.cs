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
        public async Task<List<Fichier>> getAllGroups()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseAddress + "api/groupe/getallfichier").Result;
            if (response.IsSuccessStatusCode)
            {
                List<Fichier> fichiers = await response.Content.ReadAsAsync<List<Fichier>>();
                return fichiers;
            }
            return null;
        }
    }
}
