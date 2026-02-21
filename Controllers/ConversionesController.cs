using Microsoft.AspNetCore.Mvc;

namespace ExamenUnidadUnoAPI.Controllers
{
    [ApiController]
    [Route("api/conversiones")]
    public class ConversionesController : ControllerBase
    {
        [HttpGet("temperatura")]
        public IActionResult Convertir(double valor, string de, string a)
        {
            de = de.ToUpper();
            a = a.ToUpper();

            if (de == a)
                return Ok(new { resultado = valor });

            double resultado;

            try
            {
                if (de == "C" && a == "F")
                    resultado = (valor * 9 / 5) + 32;
                else if (de == "F" && a == "C")
                    resultado = (valor - 32) * 5 / 9;
                else if (de == "C" && a == "K")
                    resultado = valor + 273.15;
                else if (de == "K" && a == "C")
                    resultado = valor - 273.15;
                else
                    return BadRequest(new { message = "Escalas inválidas. Use C, F o K" });

                return Ok(new
                {
                    valorOriginal = valor,
                    convertido = Math.Round(resultado, 2),
                    de = de,
                    a = a
                });
            }
            
            catch
            {
                return BadRequest(new { message = "Error en la conversión" });
            }
        }
    }
}