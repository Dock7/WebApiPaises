using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebApiPaises.Models
{
    public class Pais
    {
        public int Id { get; set; }

        [StringLength(30)]
        public required string Nombre { get; set; }
        public List<Provincia> Provincias { get; set; } = [];
    }
}
