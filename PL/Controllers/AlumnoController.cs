using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = new ML.Result();
           // ML.Result result = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno(); //con y sin servicio
            AlumnoServiceReference.AlumnoClient alumnoClient = new AlumnoServiceReference.AlumnoClient();//servicios
            result = alumnoClient.GetAll();//servicios
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
                return View(alumno);

            }
            else
            {
                return View(alumno);

            }
           
        }
        [HttpGet]
        public ActionResult Form(int? idAlumno)
        {
            
            ML.Alumno alumno = new ML.Alumno();

            
            if (idAlumno == null)
            {
                return View(alumno);
            }
            else
            {
                ML.Result result = new ML.Result();
                AlumnoServiceReference.AlumnoClient alumnoClient = new AlumnoServiceReference.AlumnoClient();
                result = alumnoClient.GetById(idAlumno.Value);
                // ML.Result result = BL.Alumno.GetById(idAlumno.Value);
                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = "ocurrio un problema";
                    return View("Modal");

                }
            }

        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            if (alumno.IdAlumno == 0)
            {
                AlumnoServiceReference.AlumnoClient alumnoClient = new AlumnoServiceReference.AlumnoClient();
                result = alumnoClient.Add(alumno);
               // result = BL.Alumno.Add(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Registrado con éxito";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = "ocurrio problema";
                    return View("Modal");
                }
               
            }
            
            else
            {
                result = BL.Alumno.Update(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "actualizado";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = "ocurrio un problema";
                    return View("Modal");
                }
            }

        }

        public ActionResult Delete(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Delete(alumno);
            if (result.Correct)
            {
                ViewBag.Message = "Eliminado exitosamente";
                return View("Modal");
            }
            else
            {
                ViewBag.Message = "ocurrio un problema";
                return View("Modal");
            }
        }
    }
}