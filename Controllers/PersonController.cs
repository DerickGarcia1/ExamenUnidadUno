using Microsoft.AspNetCore.Mvc;
using ExamenUnidadUnoAPI.Entities;

namespace ExamenUnidadUnoAPI.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private static List<PersonEntity> _persons = new List<PersonEntity>
        {
            new PersonEntity { DNI = "1411200100485", FirstName = "Derick", LastName = "Garcia", Gender = "Masculino", BirthDate = DateTime.Parse("02/04/2001") },
            new PersonEntity { DNI = "1411200100486", FirstName = "Maria", LastName = "Jose", Gender = "Femenino", BirthDate = DateTime.Parse("15/03/2001") },
            new PersonEntity { DNI = "1411200100487", FirstName = "Carlos", LastName = "Peña", Gender = "Masculino", BirthDate = DateTime.Parse("27/08/2001") }
        };

        //Get all
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_persons);
        }

        //Get by DNI 
        [HttpGet("{dni}")]
        public IActionResult GetOne(string dni)
        {
            var person = _persons.FirstOrDefault(p => p.DNI == dni);

            return person != null
                ? Ok(person)
                : NotFound(new { message = "Persona no encontrada" });
        }

        // Create
        [HttpPost]
        public IActionResult Create(PersonEntity person)
        {
            // Validar modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validar duplicado
            var exists = _persons.Any(p => p.DNI == person.DNI);

            if (exists)
            {
                return BadRequest(new { message = "El DNI ya está registrado" });
            }

            _persons.Add(person);

            return Created("", person);
        }

        //Update
        [HttpPut("{dni}")]
        public IActionResult Update(string dni, PersonEntity updatedPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = _persons.FirstOrDefault(p => p.DNI == dni);

            if (person == null)
            {
                return NotFound(new { message = "Persona no encontrada" });
            }

            person.FirstName = updatedPerson.FirstName;
            person.LastName = updatedPerson.LastName;

            return Ok(new { message = "Persona actualizada correctamente" });
        }

        //Delete
        [HttpDelete("{dni}")]
        public IActionResult Delete(string dni)
        {
            var person = _persons.FirstOrDefault(p => p.DNI == dni);

            if (person == null)
            {
                return NotFound(new { message = "Persona no encontrada" });
            }

            _persons.Remove(person);

            return Ok(new { message = "Persona eliminada correctamente" });
        }
    }
}