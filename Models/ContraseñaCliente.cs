using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class ContraseñaCliente
    {
        public ContraseñaCliente()
        {
            Clientes = new HashSet<Cliente>();
        }

        [Key]
        public uint IdContraseñaCliente { get; set; }
        public string Salt { get; set; }
        public string ParteEncriptada { get; set; }

        public ContraseñaCliente(string salt, string parteEncriptada)
        {
            Salt = salt;
            ParteEncriptada = parteEncriptada;
        }

        public virtual ICollection<Cliente> Clientes { get; set; }

    }
}
