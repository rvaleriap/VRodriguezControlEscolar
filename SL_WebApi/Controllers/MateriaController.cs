using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class MateriaController : ApiController
    {
        [HttpGet]
        [Route("api/Materia/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("api/Materia/Add")]
        public IHttpActionResult Add([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.Add(materia);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Materia/GetById/{IdMateria}")]

        public IHttpActionResult GetById(int idMateria)
        {
            ML.Result result = BL.Materia.GetById(idMateria);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //se utiliza metodo put en servicios
        [HttpPost]
        [Route("api/Materia/Update")]

        // PUT api/subcategoria/5
        public IHttpActionResult Put([FromBody] ML.Materia materia)
        {
            var result = BL.Materia.Update(materia);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Materia/Delete/{IdMateria}")]

        // DELETE api/subcategoria/5
        public IHttpActionResult Delete(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.IdMateria = IdMateria;
            ML.Result result = BL.Materia.Delete(materia);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
