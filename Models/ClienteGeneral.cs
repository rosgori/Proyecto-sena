using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_Sena_2.Models
{
    public partial class ClienteGeneral
    {
        public ClienteGeneral()
        {
            Cotizacions = new HashSet<Cotizacion>();
        }

        public string IdClienteGeneral { get; set; }
        public bool PersonalNatural { get; set; }
        public bool PersonaJuridica { get; set; }

        public virtual ICollection<Cotizacion> Cotizacions { get; set; }
    }
}

