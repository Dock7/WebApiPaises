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
    }
}
