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
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(baseAddress + "api/invitation/getallinvitation");

            if (response.IsSuccessStatusCode)
            {
                List<Invitation> invites = await response.Content.ReadAsAsync<List<Invitation>>();
                return invites;
            }
            return null;
        }

        public async Task<List<Invitation>> getInvitationsByClient(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(baseAddress + "api/invitation/getinvitationbyclient/" + id);

            if (response.IsSuccessStatusCode)
            {
                List<Invitation> invites = await response.Content.ReadAsAsync<List<Invitation>>();
                return invites;
            }
            return null;
        }

        public async Task<List<Client>> getGroupMembers(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(baseAddress + "api/invitation/GetGroupMember?id_groupe=" + id);
            if (response.IsSuccessStatusCode)
            {
                List<Client> clients = await response.Content.ReadAsAsync<List<Client>>();
                return clients;
            }
            return null;
        }

        public void inviteMemberToGroup(int clientId, int groupId)
        {
            HttpClient client = new HttpClient();
            Invitation i = new Invitation();
            i.id_client_fk = clientId;
            i.id_groupe_fk = groupId;
            string jsonClient = JsonConvert.SerializeObject(i);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonClient);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync(baseAddress + "api/invitation/InviteMemberToGroup", byteContent).Result;
        }

        public void removeMemberToGroup(int clientId, int groupId)
        {
            HttpClient client = new HttpClient();
            Invitation i = new Invitation();
            i.id_client_fk = clientId;
            i.id_groupe_fk = groupId;
            string jsonClient = JsonConvert.SerializeObject(i);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(baseAddress + "api/invitation/RemoveMemberFromGroup"),
                Content = new StringContent(JsonConvert.SerializeObject(i), System.Text.Encoding.UTF8, "application/json")
            };
            var response = client.SendAsync(request).Result;
        }

        public async Task answerInviteAsync(Invitation invite, bool answer)
        {
            HttpClient client = new HttpClient();
            invite.answer = answer;
            string jsonClient = JsonConvert.SerializeObject(invite);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonClient);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync(baseAddress + "api/invitation/InviteAnswer", byteContent);
        }
    }
}
