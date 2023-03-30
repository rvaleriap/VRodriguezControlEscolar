using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result MateriasGetAsignadas(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.VRodriguezContolEscolarEntities context = new DL.VRodriguezContolEscolarEntities())
                {
                   
                    var query = context.MateriasGetAsignadas(idAlumno).ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach(var obj in query)
                        {

                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;
                           
                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Materia.NombreMateria = obj.NombreMateria;
                            alumnoMateria.Materia.Costo = obj.Costo.Value;

                            alumnoMateria.Alumno = new ML.Alumno();
                            alumnoMateria.Alumno.IdAlumno = obj.IdAlumno.Value;
                            alumnoMateria.Alumno.Nombre = obj.NombreAlumno;
                            alumnoMateria.Alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumnoMateria.Alumno.ApellidoMaterno = obj.ApellidoMaterno;


                            result.Objects.Add(alumnoMateria); //boxing
                          
                        }
                        result.Correct = true;

                    }

                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pueden mostrar las materias";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = "No se logran mostrar los registros";
            }
            return result;
        }

        public static ML.Result Delete(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.VRodriguezContolEscolarEntities context = new DL.VRodriguezContolEscolarEntities())
                {
                    var query = context.AlumnoMateriaDelete(alumnoMateria.IdAlumnoMateria);
                    if(query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message ="No se puede eliminar el registro";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public static ML.Result MateriasSinAsignar (int idAlumno)
        {

            ML.Result result = new ML.Result();
            try
            {
                using(DL.VRodriguezContolEscolarEntities context = new DL.VRodriguezContolEscolarEntities())
                {
                    var query = context.AlumnoSinAsignar(idAlumno).ToList();
                    result.Objects = new List<object>();
                    if(query != null)
                    {
                        foreach (var obj in query)
                        {

                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Materia.NombreMateria = obj.Nombre;
                            alumnoMateria.Materia.Costo = obj.Costo.Value;

                            result.Objects.Add(alumnoMateria); //boxing

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo realizar la consulta";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
         
            try
            {
                using (DL.VRodriguezContolEscolarEntities context = new DL.VRodriguezContolEscolarEntities())
                {
                    var query = context.AlumnoMateriaAdd(alumnoMateria.Alumno.IdAlumno, alumnoMateria.Materia.IdMateria);
                    if (query >= 1)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se puede agregar la materia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
   
}
