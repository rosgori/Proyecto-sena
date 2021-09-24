using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class CiudadCompañium
    {
        public CiudadCompañium()
        {
            ClienteCompañia = new HashSet<ClienteCompañium>();
            Compañia = new HashSet<Compañium>();
        }

        public uint IdCiudad { get; set; }
        public string NombreCiudad { get; set; }

        public virtual ICollection<ClienteCompañium> ClienteCompañia { get; set; }
        public virtual ICollection<Compañium> Compañia { get; set; }
    }
}
