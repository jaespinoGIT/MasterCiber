using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace M8Tarea3
{
    class Program
    {
        static void Main(string[] args)
        {
            ComparadorHashes();
        }

        static void ComparadorHashes() 
        {
            Console.Clear();
            string hash;
           
            string caracteres = M8Tarea3.Settings.Default.caracteresPass;
            const Int32 BufferSize = 128;
            List<string> listaHashesBusqueda = new List<string>();
            List<string> listaHashesFichero = new List<string>();
            String line;

            using (var fileStream = File.OpenRead(M8Tarea3.Settings.Default.rutaArchivoPass))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    listaHashesBusqueda.Add(line.ToUpper());
                    listaHashesFichero.Add(line.ToUpper());
                }
            }

            Hashtable listaEncontradas = new Hashtable();
            short numeroDiccionarios = M8Tarea3.Settings.Default.numeroDiccionarios;
            for (int i = 0; i < numeroDiccionarios; i++)
            {
                using (var fileStream = File.OpenRead(string.Format(@"{0}{1}.dic", M8Tarea3.Settings.Default.rutaDiccionarios, i)))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        hash = CalcularMD5Hash(line.ToString());
                        if (listaHashesBusqueda.Contains(hash))
                        {
                            listaEncontradas.Add(hash, line.ToString());
                            Console.WriteLine("La contraseña es: " + line.ToString());
                            listaHashesBusqueda.RemoveAll(h => h == hash);
                            continue;
                        }
                    }
                }
            }

            for (int i = 0; i < caracteres.Length; i++)
            {
                hash = CalcularMD5Hash(caracteres[i].ToString());
                if (listaHashesBusqueda.Contains(hash))
                {
                    listaEncontradas.Add(hash, caracteres[i].ToString());
                    Console.WriteLine("La contraseña es: " + caracteres[i].ToString());
                    listaHashesBusqueda.Remove(hash);
                    break;
                }
                for (int j = 0; j < caracteres.Length; j++)
                {
                    string hash2 = caracteres[i].ToString() + caracteres[j].ToString();
                    hash = CalcularMD5Hash(hash2);
                    if (listaHashesBusqueda.Contains(hash))
                    {
                        listaEncontradas.Add(hash, hash2);
                        Console.WriteLine("La contraseña es: " + hash2);
                        listaHashesBusqueda.Remove(hash);
                        break;
                    }
                    for (int k = 0; k < caracteres.Length; k++)
                    {
                        string hash3 = caracteres[i].ToString() + caracteres[j].ToString() + caracteres[k].ToString();
                        hash = CalcularMD5Hash(hash3);
                        if (listaHashesBusqueda.Contains(hash))
                        {
                            listaEncontradas.Add(hash, hash3);
                            Console.WriteLine("La contraseña es: " + hash3);
                            listaHashesBusqueda.Remove(hash);
                            break;
                        }
                        for (int l = 0; l < caracteres.Length; l++)
                        {
                            string hash4 = caracteres[i].ToString() + caracteres[j].ToString() + caracteres[k].ToString() + caracteres[l].ToString();
                            hash = CalcularMD5Hash(hash4);
                            if (listaHashesBusqueda.Contains(hash))
                            {
                                listaEncontradas.Add(hash, hash4);
                                Console.WriteLine("La contraseña es: " + hash4);
                                listaHashesBusqueda.Remove(hash);
                                break;
                            }
                            for (int m = 0; m < caracteres.Length; m++)
                            {
                                string hash5 = caracteres[i].ToString() + caracteres[j].ToString() + caracteres[k].ToString() + caracteres[l].ToString() + caracteres[m].ToString();
                                hash = CalcularMD5Hash(hash5);
                                if (listaHashesBusqueda.Contains(hash))
                                {
                                    listaEncontradas.Add(hash, hash5);
                                    Console.WriteLine("La contraseña es: " + hash5);
                                    listaHashesBusqueda.Remove(hash);
                                    break;
                                }
                                for (int n = 0; n < caracteres.Length; n++)
                                {
                                    string hash6 = caracteres[i].ToString() + caracteres[j].ToString() + caracteres[k].ToString() + caracteres[l].ToString() + caracteres[m].ToString() + caracteres[n].ToString();
                                    hash = CalcularMD5Hash(hash6);
                                    if (listaHashesBusqueda.Contains(hash))
                                    {
                                        listaEncontradas.Add(hash, hash6);
                                        Console.WriteLine("La contraseña es: " + hash6);
                                        listaHashesBusqueda.Remove(hash);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("plain.txt"))
            {
                foreach (var item in listaHashesFichero)
                {
                    //Escribir las contraseñas plain.txt
                    if (listaEncontradas.ContainsKey(item))
                        writer.WriteLine(listaEncontradas[item]);
                    else
                        writer.WriteLine(writer.NewLine);                     
                }    
            }

            using (StreamWriter writer = new StreamWriter("new_passwords.txt"))
            {
                foreach (var item in listaHashesFichero)
                {
                    //Escribir las contraseñas plain.txt
                    if (listaEncontradas.ContainsKey(item))
                        writer.WriteLine(HashPassword(item));
                    else
                        writer.WriteLine(writer.NewLine);
                }
            }

            Console.ReadLine();
        }

        static string CalcularMD5Hash(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static string HashPassword(string password)
        {
            var prf = KeyDerivationPrf.HMACSHA256;
            var rng = RandomNumberGenerator.Create();
            const int iterCount = 10000;
            const int saltSize = 128 / 8;
            const int numBytesRequested = 256 / 8;
           
            var salt = new byte[saltSize];
            rng.GetBytes(salt);
            var subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

            var outputBytes = new byte[13 + salt.Length + subkey.Length];
            outputBytes[0] = 0x01; 
            WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
            WriteNetworkByteOrder(outputBytes, 5, iterCount);
            WriteNetworkByteOrder(outputBytes, 9, saltSize);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
            return Convert.ToBase64String(outputBytes);
        }
        private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }

    }
}