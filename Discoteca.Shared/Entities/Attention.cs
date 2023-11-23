using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Discoteca.Shared.Entities
{
    public class Attention
    {
        public int Id {  get; set; }

        public int EventoId { get; set; }

        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }


        public int LocationId { get; set; }

        [JsonIgnore]
        public Location Location { get; set; }

        public int BillId { get; set; }

        [JsonIgnore]
        public Bill Bill { get; set; }

        public string DocumentId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public ICollection<ProductEvent> ProductEvent {  get; set; } 

    }
}
