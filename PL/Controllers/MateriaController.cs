using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            /*  ML.Result result = BL.Materia.GetAll(); *///sin servicio
            ML.Result result = new ML.Result();
            result.Objects = new List<object>(); //con servicios
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:17114//api/");
                    var responseTask = client.GetAsync("Materia/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }
                    }
                    materia.Materias = result.Objects;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return View(materia);
            //sin servicio
            //if (result.Correct)
            //{
            //    materia.Materias = result.Objects;
            //    return View(materia);
            //}
            //else
            //{
            //    return View(materia);
            //} //termina sin servicio

        }
        [HttpGet]
        public ActionResult Form(int? idMateria)
        {
            ML.Materia materia = new ML.Materia();
            if(idMateria == null)
            {
                return View(materia);
            }
            else
            {
                // ML.Result result = BL.Materia.GetById(idMateria.Value); //sins ervicios
                ML.Result result = new ML.Result();
                try
                {
                    using(var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:17114//api/");

                        var responseTask = client.GetAsync("Materia/GetById/" + idMateria);
                        responseTask.Wait();
                        var resultAPI = responseTask.Result;

                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Materia resultItemList = new ML.Materia();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No existe el registro";
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.Message = ex.Message;
                }
                //sin servicio
                //if (result.Correct)
                //{
                   materia=(ML.Materia)result.Object;
                   return View(materia);
                //}
                //else
                //{
                //    ViewBag.Message = "ocurrio un problema";
                //    return View("Modal");
                //} //sin servicio
            }
            
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            //ML.Result result = new ML.Result();
            if (materia.IdMateria == 0)
            {
                //lineas de codigo para usar servicios
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:17114//api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", materia);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se ha registrado la materia";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha registrado la materia";
                        return PartialView("Modal");
                    }
                }
                //sin servicio para insertar
                //result = BL.Materia.Add(materia);

                //if (result.Correct)
                //{
                //    ViewBag.Message = "Registrado con éxito";
                //    return View("Modal");
                //}
                //else
                //{
                //    ViewBag.Message = "ocurrio problema";
                //    return View("Modal");
                //}

            }

            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:17114//api/");
                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Update", materia);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se ha actualizado la materia";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha actualizado la materia";
                        return PartialView("Modal");
                    }
                }
                //sin servicio para actualizar
                //result = BL.Materia.Update(materia);
                //if (result.Correct)
                //{
                //    ViewBag.Message = "actualizado";
                //    return View("Modal");
                //}
                //else
                //{
                //    ViewBag.Message = "ocurrio un problema";
                //    return View("Modal");
                //}
            }

        }
        public ActionResult Delete(ML.Materia materia)
        {
            //codigo con servicio
            int IdMateria = materia.IdMateria;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:17114//api/");

                //HTTP POST
                var postTask = client.GetAsync("Materia/Delete/" + IdMateria);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Se ha eliminado la materia";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Mensaje = "No se ha eliminado la materia";
                    return PartialView("Modal");
                }
            }
            //sin servicio
            //ML.Result result = BL.Materia.Delete(materia);
            //if (result.Correct)
            //{
            //    ViewBag.Message = "Eliminado exitosamente";
            //    return View("Modal");
            //}
            //else
            //{
            //    ViewBag.Message = "ocurrio un problema";
            //    return View("Modal");
            //}
            //sin servicio
        }
    }
}