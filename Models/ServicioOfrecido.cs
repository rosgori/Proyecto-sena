using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_Sena_2.Models
{
    public partial class ServicioOfrecido
    {
        public ServicioOfrecido()
        {
            DemandaServicios = new HashSet<DemandaServicio>();
            OfertaServicios = new HashSet<OfertaServicio>();
        }

        public string IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public uint PrecioServicio { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<DemandaServicio> DemandaServicios { get; set; }
        public virtual ICollection<OfertaServicio> OfertaServicios { get; set; }
    }
}
