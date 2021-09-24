using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class ContraseñaClienteCompañium
    {
        public ContraseñaClienteCompañium()
        {
            ClienteCompañia = new HashSet<ClienteCompañium>();
        }

        public uint IdContraseñaCompañia { get; set; }
        public string Salt { get; set; }
        public string ParteEncriptada { get; set; }

        public virtual ICollection<ClienteCompañium> ClienteCompañia { get; set; }
    }
}
