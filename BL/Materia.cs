using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VRodriguezContolEscolarEntities context = new DL.VRodriguezContolEscolarEntities())
                {
                    var query = context.MateriaGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Materia materia = new ML.Materia();

                            materia.IdMateria = obj.IdMateria;
                            materia.NombreMateria = obj.Nombre;
                            materia.Costo = obj.Costo.Value;

                            result.Objects.Add(materia);
                        }


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pueden mostrar los datos";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "No se logrA mostrar la materia";
            }
            return result;
        }
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.VRodriguezContolEscolarEntities context = new DL.VRodriguezContolEscolarEntities())
                {
                    int query = context.MateriaAdd(materia.NombreMateria, materia.Costo);
                    if(query >=1)
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
        public static ML.Result GetById(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VRodriguezContolEscolarEntities context = new DL.VRodriguezContolEscolarEntities())
                {
                    var query = context.MateriaGetById(idMateria).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (query != null)
                    {

                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = query.IdMateria;
                        materia.NombreMateria = query.NombreMateria;
                        materia.Costo = query.Costo.Value;

                        result.Object = materia; //boxing
                        result.Correct = true;

                    }

                    else
                    {
                        result.Correct = false;
                        result.Message = "No se puede mostrar la materia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "No se logrA mostrar la materia";
            }
            return result;
        }
        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VRodriguezContolEscolarEntities context = new DL.VRodriguezContolEscolarEntities())
                {
                    var query = context.MateriaUpdate(materia.IdMateria, materia.NombreMateria, materia.Costo);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se actualizo la materia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "No se logro actualizar la materia";
            }
            return result;
        }
        public static ML.Result Delete(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VRodriguezContolEscolarEntities context = new DL.VRodriguezContolEscolarEntities())
                {
                    var query = context.MateriaDelete(materia.IdMateria);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se elimino la materia";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "No se elimino el usuario";
            }
            return result;
        }
    }
}
