using Newtonsoft.Json;
using serveur.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows.Forms;

namespace serveur
{
    public class FichierController : ApiController
    {


        /// <summary>
        /// Upload a file on the server
        /// </summary>
        /// <exception cref="HttpResponseException"/>
        /// 
        /// <returns></returns>
        /// /api/fichier/upload
        [HttpPost]
        public async Task<IHttpActionResult> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            Fichier f = null;
            string filename = null;
            byte[] fileBytes = null;
            foreach (var file in provider.Contents)
            {
                if (file.Headers?.ContentDisposition?.FileName != null)
                {
                    filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                    fileBytes = await file.ReadAsByteArrayAsync();
                }
                else
                {
                    string json = await file.ReadAsStringAsync();
                    f = JsonConvert.DeserializeObject<Fichier>(json);
                }
            }

            //Upload
            if (filename != null && fileBytes != null && f != null)
            {
                API api = new API();
                bool success = false;
                string fileToDelete = "";
                if (f.id_fichier != 0)
                {
                    Fichier fbd = api.GetFile(f.id_fichier);
                    if (fbd.nom != f.nom)
                    {
                        success = api.ModifyFile(f);
                        fileToDelete = fbd.nom;
                    }
                    else
                    {
                        success = true;
                    }
                }
                else
                {
                    success = api.CreateFile(f);
                }

                if (success)
                {
                    string pathString = Path.GetDirectoryName(Application.ExecutablePath);
                    pathString = Path.Combine(pathString, "groupfiles");
                    pathString = Path.Combine(pathString, f.id_groupe_fk.ToString());
                    Directory.CreateDirectory(pathString);

                    if (fileToDelete != "")
                    {
                        fileToDelete = Path.Combine(pathString, fileToDelete);
                        if (System.IO.File.Exists(fileToDelete))
                        {
                            try
                            {
                                System.IO.File.Delete(fileToDelete);
                            }
                            catch (System.IO.IOException e)
                            {
                                Console.Error.WriteLine(e.Message);
                            }
                        }
                    }

                    pathString = Path.Combine(pathString, f.nom);

                    if (!System.IO.File.Exists(pathString))
                    {
                        using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                        {
                            foreach (byte b in fileBytes)
                            {
                                fs.WriteByte(b);
                            }
                        }
                    }
                }
            }
            return Ok();
        }

        [HttpGet]
        // GET api/fichier/download?id_fichier=
        public HttpResponseMessage Download([FromUri]int id_fichier)
        {
            Fichier f = GetFile(id_fichier);
            byte[] readBuffer = { };

            try
            {
                string pathString = Path.GetDirectoryName(Application.ExecutablePath);
                pathString = Path.Combine(pathString, "groupfiles");
                pathString = Path.Combine(pathString, f.id_groupe_fk.ToString());
                pathString = Path.Combine(pathString, f.nom);
                readBuffer = System.IO.File.ReadAllBytes(pathString);
            } 
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            using (HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK))
            {
                result.Content = new ByteArrayContent(readBuffer);
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = f.nom;
                return result;
            }
        }


        [HttpPost]
        // POST api/fichier/createfile
        public bool CreateFile(Fichier f)
        {
            return new API().CreateFile(f);
        }

        [HttpPost]
        // POST api/fichier/modifyfile
        public bool ModifyFile(Fichier f)
        {
            return new API().ModifyFile(f);
        }

        [HttpDelete]
        // Delete api/fichier/deletefile
        public bool DeleteFile(Fichier f)
        {
            API api = new API();
            if (api.DeleteFile(f))
            {
                string pathString = Path.GetDirectoryName(Application.ExecutablePath);
                pathString = Path.Combine(pathString, "groupfiles");
                pathString = Path.Combine(pathString, f.id_groupe_fk.ToString());
                pathString = Path.Combine(pathString, f.nom);
                if (System.IO.File.Exists(pathString))
                {
                    try
                    {
                        System.IO.File.Delete(pathString);
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.Error.WriteLine(e.Message);
                    }
                }
                return true;
            }
            return false;
        }

        [HttpGet]
        // GET api/fichier/getfile/{id}
        public Fichier GetFile(int id)
        {
            return new API().GetFile(id);
        }

        [HttpGet]
        // GET api/fichier/GetFileFromGroup?id_groupe=
        public List<Fichier> GetFileFromGroup([FromUri]int id_groupe)
        {
            return new API().GetFileFromGroup(id_groupe);
        }
    }
}

