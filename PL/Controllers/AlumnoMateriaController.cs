using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        [HttpGet]
        public ActionResult AlumnoGetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();

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
        public ActionResult Form(int idAlumno)
        {
            ML.Result result = BL.AlumnoMateria.MateriasGetAsignadas(idAlumno);

            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
            ML.Result resultalumno = BL.Alumno.GetById(idAlumno);

            alumnomateria.AlumnoMaterias = result.Objects;
            alumnomateria.Alumno = ((ML.Alumno)resultalumno.Object);

            return View(alumnomateria); 
           
        }
        [HttpGet]
        public ActionResult Delete(ML.AlumnoMateria alumnoMateria)
        {
           
            ML.Result result = BL.AlumnoMateria.Delete(alumnoMateria);

            if (result.Correct)
            {
                ViewBag.message = "Se ha eliminado el registro";
            }
            else
            {
                ViewBag.message = "No se ha podido eliminar";
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult MateriasSinAsignar(int idAlumno)
        {
            ML.Result result = BL.AlumnoMateria.MateriasSinAsignar(idAlumno);

            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
            ML.Result resultalumno = BL.Alumno.GetById(idAlumno);

            alumnomateria.AlumnoMaterias = result.Objects;
            alumnomateria.Alumno = ((ML.Alumno)resultalumno.Object);

            return View(alumnomateria);
        }
        [HttpPost]
        public ActionResult MateriasSinAsignar(ML.AlumnoMateria alumnomateria)
        {

            ML.Result result = new ML.Result();
            if (alumnomateria.AlumnoMaterias != null)
            {
                foreach (string IdMateria in alumnomateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnomateriaItem = new ML.AlumnoMateria();

                    alumnomateriaItem.Alumno = new ML.Alumno();
                    alumnomateriaItem.Alumno.IdAlumno = alumnomateria.Alumno.IdAlumno;

                    alumnomateriaItem.Materia = new ML.Materia();
                    alumnomateriaItem.Materia.IdMateria = int.Parse(IdMateria);

                    ML.Result resul = BL.AlumnoMateria.Add(alumnomateriaItem);

                }
                result.Correct = true;
                ViewBag.Message = "Se ha actualizado al alumno";
                ViewBag.IdAlumno = alumnomateria.Alumno.IdAlumno;

            }
            else
            {
                result.Correct = false;
                ViewBag.message = "No se puede insertar el registro";
            }
            return PartialView("Modal");
        }
      

    }
}