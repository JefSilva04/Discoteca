using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoteca.Shared.Entities
{
    public class Attention
    {
        public int Id {  get; set; }

        public int EventoId { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public Location Location { get; set; }

        public int LocationId { get; set; }

        public Bill Bill { get; set; }

        public int BillId { get; set; }

        public ICollection<ProductEvent> ProductEvent {  get; set; } 

    }
}
