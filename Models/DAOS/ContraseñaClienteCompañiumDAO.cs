using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Proyecto_sena.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

#nullable disable

namespace Proyecto_sena.Models.DAOS
{
    public class ContraseñaClienteCompañiumDAO
    {
        private static proyecto_innubeContext base_datos = new proyecto_innubeContext();

        public static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            using (SHA256 algorithm = SHA256.Create())
            {

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