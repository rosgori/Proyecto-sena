using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class Cliente
    {
        public string IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string CorreoElectronicoCliente { get; set; }
        public uint? IdContraseñaCliente { get; set; }

        public virtual ContraseñaCliente IdContraseñaClienteNavigation { get; set; }
    }
}
