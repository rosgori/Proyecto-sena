using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Proyecto_sena.Models;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace Proyecto_sena.Models.DAOS
{
    public class ClienteCompañiaDAO
    {
        private static proyecto_innubeContext base_datos = new proyecto_innubeContext();

        public static string CrearId()
        {
            var id_nuevo = new StringBuilder();
            string inicio_exp = "CM";
            Random num_random = new Random();
            var num = num_random.Next(100000, 9999999);
            id_nuevo.Append(inicio_exp);
            id_nuevo.Append(num);
            return id_nuevo.ToString();
        }

        public static ContraseñaClienteCompañium ExisteUsuario(string correo, string contraseña)
        {
            var existe = base_datos.ClienteCompañia.ToList().Exists(c => c.CorreoElectronicoCompañia == correo);

            if (!existe) {
                return null;
            }

            ClienteCompañium persona = base_datos.ClienteCompañia.FirstOrDefault(c => c.CorreoElectronicoCompañia == correo);

            uint? id_contraseña = persona.IdContraseñaCompañia;

            ContraseñaClienteCompañium contra = base_datos.ContraseñaClienteCompañia.Find(id_contraseña);

            var salt = contra.Salt;
            byte[] bytes_contraseña = Encoding.UTF8.GetBytes(contraseña);
            byte[] bytes_salt = Encoding.UTF8.GetBytes(salt);

            var contraseña_encriptada = ContraseñaClienteCompañiumDAO.GenerateSaltedHash(bytes_contraseña, bytes_salt);
            var contraseña_encriptada2 = Convert.ToBase64String(contraseña_encriptada);

            existe = base_datos.ContraseñaClienteCompañia.ToList().Exists(u => u.ParteEncriptada == contraseña_encriptada2);

            if (!existe) {
                return null;
            }

            var usuarioLogueado = base_datos.ContraseñaClienteCompañia.FirstOrDefault(u => u.ParteEncriptada == contraseña_encriptada2);

            return usuarioLogueado;
        }
    }
}