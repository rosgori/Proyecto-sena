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

        
        public static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
