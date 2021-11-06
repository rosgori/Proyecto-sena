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
    }
}