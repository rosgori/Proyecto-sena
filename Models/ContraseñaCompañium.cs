using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_Sena_2.Models
{
    public partial class ContraseñaCompañium
    {
        public ContraseñaCompañium()
        {
            Compañia = new HashSet<Compañium>();
        }

        public uint IdContraseñaCompañia { get; set; }
        public string Salt { get; set; }
        public string ParteEncriptada { get; set; }

        public virtual ICollection<Compañium> Compañia { get; set; }
    }
}
