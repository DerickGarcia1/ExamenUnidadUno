using Microsoft.AspNetCore.Mvc;

namespace ExamenUnidadUnoAPI.Controllers
{
    [ApiController]
    [Route("api/matematicas")]
    public class MatematicasController : ControllerBase
    {
        [HttpGet("tabla/{numero}")]
        public IActionResult Tabla(int numero, int hasta = 10)
        {
            if (hasta <= 0)
                return BadRequest(new { message = "El límite debe ser mayor a 0" });

            var resultado = new List<string>();

            for (int i = 1; i <= hasta; i++)
            {
                resultado.Add($"{numero} x {i} = {numero * i}");
            }

            return Ok(resultado);
        }
    }
}