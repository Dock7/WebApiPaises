using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPaises.Models;

namespace WebApiPaises.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pais>> Get()
        {
            return _context.Paises.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Pais> GetById(int id)
        {
            var pais = _context.Paises.FirstOrDefault(x => x.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            return pais;
        }

        [HttpPost]
        public ActionResult<Pais> Post([FromBody] Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Paises.Add(pais);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = pais.Id }, pais);
        }
    }
}
