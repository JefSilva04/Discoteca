using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoteca.Shared.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string NombreCliente { get; set; } = null;

        [Required]
        public string DireccionCliente { get; set; } = null;

        [Required]
        public string TelefonoCliente { get; set; } = null;

        [Required]
        public string EmailCliente { get; set; } = null;

        [Required]
        public string FechaNacimiento { get; set; } = null;

        public ICollection<Attention> Attention { get; set; }


    }
}
