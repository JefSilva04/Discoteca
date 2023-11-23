using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Discoteca.Shared.Entities
{
    public class Bill
    {
        public int Id { get; set; }

        [Required]
        public float Costo { get; set; }

        [JsonIgnore]
        public ICollection<Attention> Attention { get; set; }
    }
}
