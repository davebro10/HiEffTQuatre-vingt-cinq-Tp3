using Newtonsoft.Json;
using serveur.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace client.API
{
    public class InvitationAPI : API
    {
        public async Task<List<Invitation>> GetAllGroups()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(BaseAddress + "api/invitation/getallinvitation"))
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

        public async Task<List<Invitation>> GetInvitationsByClient(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(BaseAddress + "api/invitation/getinvitationbyclient/" + id))
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

        public async Task<List<Client>> GetGroupMembers(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(BaseAddress + "api/invitation/GetGroupMember?id_groupe=" + id))
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

        public async Task InviteMemberToGroupAsync(int clientId, int groupId)
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
                    response = await client.PostAsync(BaseAddress + "api/invitation/InviteMemberToGroup", byteContent);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            response?.Dispose();
        }

        public async Task RemoveMemberToGroupAsync(int clientId, int groupId)
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
                    request.RequestUri = new Uri(BaseAddress + "api/invitation/RemoveMemberFromGroup");
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

        public async Task AnswerInviteAsync(Invitation invite, bool answer)
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
                    response = await client.PostAsync(BaseAddress + "api/invitation/InviteAnswer", byteContent);
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
