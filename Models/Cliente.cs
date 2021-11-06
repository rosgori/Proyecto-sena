using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class Cliente
    {
        [Key]
        public string IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }

        [EmailAddress]
        public string CorreoElectronicoCliente { get; set; }
        public uint IdContraseñaCliente { get; set; }

        public virtual ContraseñaCliente IdContraseñaClienteNavigation { get; set; }

        public Cliente(string idCliente, string nombreCliente, string apellidoCliente, string correoElectronicoCliente, uint idContraseñaCliente)
        {
            IdCliente = idCliente;
            NombreCliente = nombreCliente;
            ApellidoCliente = apellidoCliente;
            CorreoElectronicoCliente = correoElectronicoCliente;
            IdContraseñaCliente = idContraseñaCliente;
        }

        public Cliente () {

        }
    }
}
