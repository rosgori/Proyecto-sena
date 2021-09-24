using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_Sena_2.Models
{
    public partial class DemandaServicio
    {
        public uint IdCotizacion { get; set; }
        public string IdServicio { get; set; }
        public DateTime? FechaCotizacion { get; set; }
        public sbyte? Cantidad { get; set; }

        public virtual Cotizacion IdCotizacionNavigation { get; set; }
        public virtual ServicioOfrecido IdServicioNavigation { get; set; }
    }
}
