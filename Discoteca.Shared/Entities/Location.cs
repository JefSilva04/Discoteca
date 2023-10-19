﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoteca.Shared.Entities
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string TipoMesa { get; set; } = null;

        public ICollection<Attention> Attention { get; set; }
    }
}
