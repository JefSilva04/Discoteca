using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Discoteca.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string NombreProducto { get; set; } = null;

        [Required]
        public float CostoProducto { get; set; }

        [JsonIgnore]
        public ICollection<ProductEvent> ProductEvent { get; set; }
    }
}
