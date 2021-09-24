using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_Sena_2.Models
{
    public partial class OfertaServicio
    {
        public string IdServicio { get; set; }
        public string IdCompañia { get; set; }

        public virtual Compañium IdCompañiaNavigation { get; set; }
        public virtual ServicioOfrecido IdServicioNavigation { get; set; }
    }
}
