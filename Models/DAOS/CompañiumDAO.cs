using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Proyecto_sena.Models;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace Proyecto_sena.Models.DAOS
{
    public class CompañiumDAO
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

        public static ContraseñaCompañium ExisteUsuario(string correo, string contraseña)
        {
            var existe = base_datos.Compañia.ToList().Exists(c => c.CorreoElectronicoCompañia == correo);

            if (!existe) {
                return null;
            }

            Compañium persona = base_datos.Compañia.FirstOrDefault(c => c.CorreoElectronicoCompañia == correo);

            uint? id_contraseña = persona.IdContraseñaCompañia;

            ContraseñaCompañium contra = base_datos.ContraseñaCompañia.Find(id_contraseña);

            var salt = contra.Salt;
            byte[] bytes_contraseña = Encoding.UTF8.GetBytes(contraseña);
            byte[] bytes_salt = Encoding.UTF8.GetBytes(salt);

            var contraseña_encriptada = ContraseñaClienteDAO.GenerateSaltedHash(bytes_contraseña, bytes_salt);
            var contraseña_encriptada2 = Convert.ToBase64String(contraseña_encriptada);

            existe = base_datos.ContraseñaCompañia.ToList().Exists(u => u.ParteEncriptada == contraseña_encriptada2);

            if (!existe) {
                return null;
            }

            var usuarioLogueado = base_datos.ContraseñaCompañia.FirstOrDefault(u => u.ParteEncriptada == contraseña_encriptada2);

            return usuarioLogueado;
        }
    }
}
