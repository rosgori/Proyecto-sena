using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_Sena_2.Models
{
    public partial class ClienteCompañium
    {
        public string IdClienteCompañia { get; set; }
        public string NombreCompañia { get; set; }
        public string TelefonoCompañia { get; set; }
        public string CorreoElectronicoCompañia { get; set; }
        public string DireccionCompañia { get; set; }
        public uint IdContraseñaCompañia { get; set; }
        public string NitCompañia { get; set; }
        public uint? IdCiudad { get; set; }
        public uint? IdDepartamento { get; set; }

        public virtual CiudadCompañium IdCiudadNavigation { get; set; }
        public virtual ContraseñaClienteCompañium IdContraseñaCompañiaNavigation { get; set; }
        public virtual DepartamentoCompañium IdDepartamentoNavigation { get; set; }
    }
}
