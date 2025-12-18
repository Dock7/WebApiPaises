using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiPaises.Models
{
    public class Provincia
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        [ForeignKey("Pais")]
        public int PaisId { get; set; }
        [JsonIgnore]
        public Pais? Pais { get; set; }
    }
}
