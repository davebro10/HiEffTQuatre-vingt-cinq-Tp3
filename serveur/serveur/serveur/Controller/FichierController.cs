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
                if (file.Headers.ContentDisposition.FileName != null)
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
                                Console.WriteLine(e.Message);
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

        [HttpPost]
        // POST api/fichier/createfile
        public bool CreateFile(Fichier f)
        {
            API api = new API();
            return api.CreateFile(f);
        }

        [HttpPost]
        // POST api/fichier/modifyfile
        public bool ModifyFile(Fichier f)
        {
            API api = new API();
            return api.ModifyFile(f);
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
                        Console.WriteLine(e.Message);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        // GET api/fichier/getfile/{id}
        public Fichier GetFile(int id)
        {
            API api = new API();
            Fichier f = api.GetFile(id);

            return f;
        }
    }
}

