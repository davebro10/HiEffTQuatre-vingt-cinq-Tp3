using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using serveur.Models;
using Newtonsoft.Json;

namespace client.API
{
    class InvitationAPI : API
    {
        public async Task<List<Invitation>> getAllGroups()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(baseAddress + "api/invitation/getallinvitation"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<List<Invitation>>();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return new List<Invitation>();
        }

        public async Task<List<Invitation>> getInvitationsByClient(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(baseAddress + "api/invitation/getinvitationbyclient/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<List<Invitation>>();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return new List<Invitation>();
        }

        public async Task<List<Client>> getGroupMembers(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(baseAddress + "api/invitation/GetGroupMember?id_groupe=" + id))
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

        public async Task inviteMemberToGroupAsync(int clientId, int groupId)
        {
            Invitation i = new Invitation
            {
                id_client_fk = clientId,
                id_groupe_fk = groupId
            };
            string jsonClient = JsonConvert.SerializeObject(i);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonClient);
            HttpResponseMessage response = null;

            try
            {
                using (HttpClient client = new HttpClient())
                using (var byteContent = new ByteArrayContent(buffer))
                {
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(baseAddress + "api/invitation/InviteMemberToGroup", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public async Task removeMemberToGroupAsync(int clientId, int groupId)
        {
            Invitation i = new Invitation
            {
                id_client_fk = clientId,
                id_groupe_fk = groupId
            };
            string jsonClient = JsonConvert.SerializeObject(i);
            HttpResponseMessage response = null;

            try
            {
                using (HttpClient client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(baseAddress + "api/invitation/RemoveMemberFromGroup");
                    request.Content = new StringContent(JsonConvert.SerializeObject(i), System.Text.Encoding.UTF8, "application/json");
                    response = await client.SendAsync(request);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public async Task answerInviteAsync(Invitation invite, bool answer)
        {
            invite.answer = answer;
            string jsonClient = JsonConvert.SerializeObject(invite);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonClient);
            HttpResponseMessage response = null;

            try
            {
                using (HttpClient client = new HttpClient())
                using (var byteContent = new ByteArrayContent(buffer))
                {
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(baseAddress + "api/invitation/InviteAnswer", byteContent);
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
