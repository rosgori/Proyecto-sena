using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_sena.Models
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

        public ClienteGeneral(string id_cliente_general, bool persona_natural, bool persona_juridica)
        {
            IdClienteGeneral = id_cliente_general;
            PersonalNatural = persona_natural;
            PersonaJuridica = persona_juridica;
        }
    }
}

