using Microsoft.AspNetCore.Mvc;

namespace ExamenUnidadUnoAPI.Controllers
{
    [ApiController]
    [Route("api/salud")]
    public class SaludController : ControllerBase
    {
        [HttpGet("imc")]
        public IActionResult CalcularIMC(double peso, double altura)
        {
            if (peso <= 0 || altura <= 0)
            {
                return BadRequest(new { message = "Peso y altura deben ser mayores a 0" });
            }

            double imc = peso / (altura * altura);
            string clasificacion;

            if (imc < 18.5)
                clasificacion = "Bajo peso";
            else if (imc < 25)
                clasificacion = "Normal";
            else if (imc < 30)
                clasificacion = "Sobrepeso";
            else
                clasificacion = "Obesidad";

            return Ok(new
            {
                IMC = Math.Round(imc, 2),
                Clasificacion = clasificacion
            });
        }
    }
}