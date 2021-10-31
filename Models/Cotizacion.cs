using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class Cotizacion
    {
        public Cotizacion()
        {
            DemandaServicios = new HashSet<DemandaServicio>();
        }

        public uint IdCotizacion { get; set; }
        public uint PrecioTotal { get; set; }
        public string IdClienteGeneral { get; set; }
        public uint Subtotal { get; set; }

        public virtual ClienteGeneral IdClienteGeneralNavigation { get; set; }
        public virtual ICollection<DemandaServicio> DemandaServicios { get; set; }
    }
}
