using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class ContraseñaClienteCompañium
    {
        // Atributos
        public uint IdContraseñaCompañia { get; set; }
        public string Salt { get; set; }
        public string ParteEncriptada { get; set; }

        public virtual ICollection<ClienteCompañium> ClienteCompañia { get; set; }

        // Constructores 

        public ContraseñaClienteCompañium()
        {
            ClienteCompañia = new HashSet<ClienteCompañium>();
        }

        public ContraseñaClienteCompañium(string salt, string parteEncriptada)
        {
            Salt = salt;
            ParteEncriptada = parteEncriptada;
        }
    }
}
