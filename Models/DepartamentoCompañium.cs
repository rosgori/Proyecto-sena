using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class DepartamentoCompañium
    {
        public DepartamentoCompañium()
        {
            ClienteCompañia = new HashSet<ClienteCompañium>();
            Compañia = new HashSet<Compañium>();
        }

        public uint IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }

        public virtual ICollection<ClienteCompañium> ClienteCompañia { get; set; }
        public virtual ICollection<Compañium> Compañia { get; set; }
    }
}
