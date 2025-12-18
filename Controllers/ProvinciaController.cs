using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPaises.Models;

namespace WebApiPaises.Controllers
{
    [Route("api/Pais/{PaisId:int}/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProvinciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> GetAll(int PaisId)
        {
            return _context.Provincias.Where(x => x.PaisId == PaisId).ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Provincia> GetById(int id)
        {
            var provincia = _context.Provincias.FirstOrDefault(x => x.Id == id);

            if (provincia == null)
            {
                return NotFound();
            }

            return provincia;
        }

        [HttpPost]
        public ActionResult<Provincia> Create(int PaisId, [FromBody] Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            provincia.PaisId = PaisId;
            _context.Provincias.Add(provincia);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new { id = provincia.Id }, provincia);
        }

        [HttpPut("{id:int}")]
        public ActionResult Update(int PaisId, int id, [FromBody] Provincia provincia)
        {
            if (id != provincia.Id || provincia.PaisId != PaisId)
            {
                return BadRequest();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Provincias.Update(provincia);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var provincia = _context.Provincias.FirstOrDefault(x => x.Id == id);

            if (provincia == null)
            {
                return NotFound();
            }

            _context.Provincias.Remove(provincia);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
