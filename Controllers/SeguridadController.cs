using Microsoft.AspNetCore.Mvc;
using ExamenUnidadUnoAPI.Entities;
using System.Text.RegularExpressions;

namespace ExamenUnidadUnoAPI.Controllers
{
    [ApiController]
    [Route("api/seguridad")]
    public class SeguridadController : ControllerBase
    {
        [HttpPost("validar-password")]
        public IActionResult ValidarPassword(PasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var password = request.Password;

            if (password.Length < 8)
                return BadRequest(new { message = "Debe tener al menos 8 caracteres" });

            if (!Regex.IsMatch(password, "[A-Z]"))
                return BadRequest(new { message = "Debe tener una mayúscula" });

            if (!Regex.IsMatch(password, "[a-z]"))
                return BadRequest(new { message = "Debe tener una minúscula" });

            if (!Regex.IsMatch(password, "[0-9]"))
                return BadRequest(new { message = "Debe tener un número" });

            if (!Regex.IsMatch(password, "[@#$%&*]"))
                return BadRequest(new { message = "Debe tener un carácter especial (@,#,$,%,&,*)" });

            return Ok(new { message = "Contraseña válida" });
        }
    }
}

