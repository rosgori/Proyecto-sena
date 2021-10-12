using System;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace Proyecto_sena.Models
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

        public string CrearId()
        {            
            var id_nuevo = new StringBuilder();
            string inicio_exp = "CM";
            Random num_random = new Random();
            var num = num_random.Next(100000, 9999999);
            id_nuevo.Append(inicio_exp);
            id_nuevo.Append(num);
            return id_nuevo.ToString();
        }
    }
}
