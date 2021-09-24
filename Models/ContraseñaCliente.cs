using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class ContraseñaCliente
    {
        public ContraseñaCliente()
        {
            Clientes = new HashSet<Cliente>();
        }

        public uint IdContraseñaCliente { get; set; }
        public string Salt { get; set; }
        public string ParteEncriptada { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
