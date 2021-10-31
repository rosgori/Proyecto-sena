using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class Compañium
    {
        public Compañium()
        {
            OfertaServicios = new HashSet<OfertaServicio>();
            ResultadoEvaluacions = new HashSet<ResultadoEvaluacion>();
        }

        public string IdCompañia { get; set; }
        public string NombreCompañia { get; set; }
        public string TelefonoCompañia { get; set; }
        public string CorreoElectronicoCompañia { get; set; }
        public string DireccionCompañia { get; set; }
        public uint IdContraseñaCompañia { get; set; }
        public string NitCompañia { get; set; }
        public uint? IdCiudad { get; set; }
        public uint? IdDepartamento { get; set; }

        public virtual CiudadCompañium IdCiudadNavigation { get; set; }
        public virtual ContraseñaCompañium IdContraseñaCompañiaNavigation { get; set; }
        public virtual DepartamentoCompañium IdDepartamentoNavigation { get; set; }
        public virtual ICollection<OfertaServicio> OfertaServicios { get; set; }
        public virtual ICollection<ResultadoEvaluacion> ResultadoEvaluacions { get; set; }
    }
}
