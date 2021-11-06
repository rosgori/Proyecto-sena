using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Proyecto_sena.Models;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace Proyecto_sena.Models.DAOS
{
    public class ClienteDao
    {
        private static proyecto_innubeContext base_datos = new proyecto_innubeContext();

        public static string CrearId()
        {
            var id_nuevo = new StringBuilder();
            string inicio_exp = "CC";
            Random num_random = new Random();
            var num = num_random.Next(100000, 9999999);
            id_nuevo.Append(inicio_exp);
            id_nuevo.Append(num);
            return id_nuevo.ToString();
        }

        public static ContraseñaCliente ExisteUsuario(string correo, string contraseña)
        {
            var existe = base_datos.Clientes.ToList().Exists(c => c.CorreoElectronicoCliente == correo);

            Cliente persona = base_datos.Clientes.FirstOrDefault(c => c.CorreoElectronicoCliente == correo);

            uint? id_contraseña = persona.IdContraseñaCliente;

            ContraseñaCliente contra = base_datos.ContraseñaClientes.Find(id_contraseña);

            var salt = contra.Salt;
            byte[] bytes_contraseña = Encoding.UTF8.GetBytes(contraseña);
            byte[] bytes_salt = Encoding.UTF8.GetBytes(salt);

            var contraseña_encriptada = ContraseñaClienteDAO.GenerateSaltedHash(bytes_contraseña, bytes_salt);
            var contraseña_encriptada2 = Convert.ToBase64String(contraseña_encriptada);

            existe = base_datos.ContraseñaClientes.ToList().Exists(u => u.ParteEncriptada == contraseña_encriptada2);

            var usuarioLogueado = base_datos.ContraseñaClientes.FirstOrDefault(u => u.ParteEncriptada == contraseña_encriptada2);

            return usuarioLogueado;
        }
    }
}
