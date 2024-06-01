using ADSProject.Interfaces;
using ADSProject.Models;
using ADSProject.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ADSProject01.Controllers
{
    [Route("api/profesores/")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesor profesor;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public ProfesorController(IProfesor profesor)
        {
            this.profesor = profesor;
        }

        [HttpPost("agregarProfesor")]

        public ActionResult<string> AgregarProfesor([FromBody] Profesor profesor)
        {
            try
            {
                //verifica que todas las validaciones por atributo del modelo este correctas
                if (!ModelState.IsValid)
                {

                    // en caso de no cumplir todas las validaciones se procede a retornar una respuesta erronea
                    return BadRequest(ModelState);
                }
                int contador = this.profesor.AgregarProfesor(profesor);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con exito";
                    pMensajeUsuario = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al insertar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("actualizarProfesor/{idProfesor}")]

        public ActionResult<string> ActualizarProfesor(int idProfesor, [FromBody] Profesor profesor)
        {
            try
            {
                //verifica que todas las validaciones por atributo del modelo este correctas
                if (!ModelState.IsValid)
                {

                    // en caso de no cumplir todas las validaciones se procede a retornar una respuesta erronea
                    return BadRequest(ModelState);
                }
                int contador = this.profesor.ActualizarProfesor(idProfesor, profesor);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado correctamente";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpDelete("eliminarProfesor/{idProfesor}")]

        public ActionResult<string> EliminarProfesor(int idProfesor)
        {
            try
            {
                bool eliminado = this.profesor.EliminarProfesor(idProfesor);
                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pCodRespuesta;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("obtenerProfesorPorID/{idProfesor}")]

        public ActionResult<Profesor> ObtenerProfesorPorId(int idProfesor)
        {
            try
            {
                Profesor carrera = this.profesor.ObtenerProfesorPorId(idProfesor);

                if (profesor != null)
                {
                    return Ok(profesor);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron registros";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("obtenerProfesores")]

        public ActionResult<List<Profesor>> ObtenerProfesores()
        {
            try
            {
                List<Profesor> lstProfesor = this.profesor.ObtenerTodosLosProfesores();

                return Ok(lstProfesor);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}