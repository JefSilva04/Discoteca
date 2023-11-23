using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Discoteca.Shared.Entities
{
    public class ProductEvent
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }

        public int EventId { get; set; }

        [JsonIgnore]
        public Attention Attention { get; set; }

    }
}
