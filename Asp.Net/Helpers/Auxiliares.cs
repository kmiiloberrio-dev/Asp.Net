using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class Auxiliares
    {
        public static string EncriptarContrasenia(string contrasenia)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();

            byte[] passbytes = (new UnicodeEncoding()).GetBytes(contrasenia);
            byte[] pass = sha.ComputeHash(passbytes);

            return Convert.ToBase64String(pass);
        }


        public string CrearContraseña(int largo)
        {
            const string pass = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < largo--)
            {
                res.Append(pass[rnd.Next(pass.Length)]);
            }
            return res.ToString();
        }

        public static string Serializar<T>(List<T> lista, string archivo, char separadorCampo, char separadorRegistro, bool incluirCabeceras = true)
        {
            StringBuilder sb = new StringBuilder();
            PropertyInfo[] propiedades = lista[0].GetType().GetProperties();
            if (incluirCabeceras)
            {
                for (int i = 0; i < propiedades.Length; i++)
                {
                    sb.Append(propiedades[i].Name);
                    if (i < propiedades.Length - 1) sb.Append(separadorCampo);
                }
                sb.Append(separadorRegistro);
            }

            for (int j = 0; j < lista.Count; j++)
            {
                propiedades = lista[j].GetType().GetProperties();
                for (int i = 0; i < propiedades.Length; i++)
                {
                    if (propiedades[i].GetValue(lista[j], null) != null) sb.Append(propiedades[i].GetValue(lista[j], null).ToString());
                    else sb.Append("");
                    if (i < propiedades.Length - 1) sb.Append(separadorCampo);
                }
                if (j < lista.Count - 1) sb.Append(separadorRegistro);
            }
            return sb.ToString();
        }

        public static List<T> Deserializar<T>(string archivo, char separadorCampo, char separadorRegistro)
        {
            List<T> lista = new List<T>();
            if (File.Exists(archivo))
            {
                string contenido = File.ReadAllText(archivo);
                string[] registros = contenido.Split(separadorRegistro);
                string[] campos;
                string[] cabecera = registros[0].Split(separadorCampo);
                string registro;
                Type tipoObj;
                T obj;
                dynamic valor;
                Type tipoCampo;
                for (int i = 1; i < registros.Length; i++)
                {
                    registro = registros[i];
                    tipoObj = typeof(T);
                    obj = (T)Activator.CreateInstance(tipoObj);
                    campos = registro.Split(separadorCampo);
                    for (int j = 0; j < campos.Length; j++)
                    {
                        tipoCampo = obj.GetType().GetProperty(cabecera[j]).PropertyType;
                        valor = Convert.ChangeType(campos[j], tipoCampo);
                        obj.GetType().GetProperty(cabecera[j]).SetValue(obj, valor);
                    }
                    lista.Add(obj);
                }
            }
            return (lista);
        }
    }
}
