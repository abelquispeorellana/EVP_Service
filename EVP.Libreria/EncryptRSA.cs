using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EVP.Libreria
{
    public class EncryptRSA
    {
        /// <summary>
        /// Si no se inicializa privateKeys o publicKey, se mostrar un cuadro de dialogo 
        /// solicitando donde se guardará las llaves
        /// </summary> 
        public static EncryptRSAValor CrearClave(int TamanioClave)
        {
            try
            {
                RSACryptoServiceProvider RSACryptoServiceProvider = new RSACryptoServiceProvider(TamanioClave);
                string ClavePublicaPrivada = TamanioClave + "|" + RSACryptoServiceProvider.ToXmlString(true);
                string ClavePublica = TamanioClave + "|" + RSACryptoServiceProvider.ToXmlString(false);
                return new EncryptRSAValor() { Privada = ClavePublicaPrivada, Publica = ClavePublica };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string Encriptar(string Valor, string ClavePublica)
        {
            if (Valor != null && Valor.Trim().Length != 0)
            {
                if (ClavePublica != null)
                {
                    try
                    {
                        string bitStrengthString = ClavePublica.Substring(0, ClavePublica.IndexOf("|") + 1);
                        var valuetempkeyPublic = ClavePublica.Replace(bitStrengthString, "");
                        int dwKeySize = Convert.ToInt32(bitStrengthString.Replace("|", ""));

                        // TODO: Agregar controladores de excepción adecuados
                        RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
                        rsaCryptoServiceProvider.FromXmlString(valuetempkeyPublic);
                        int keySize = dwKeySize / 8;
                        byte[] bytes = Encoding.UTF32.GetBytes(Valor);
                        // La función hash en uso por .NET RSACryptoServiceProvider aquí es SHA1
                        // int maxLength = (keySize) - 2 - (2 * SHA1.Create (). ComputeHash (rawBytes) .Length);
                        int maxLength = keySize - 42;
                        int dataLength = bytes.Length;
                        int iterations = dataLength / maxLength;
                        StringBuilder stringBuilder = new StringBuilder();
                        for (int i = 0; i <= iterations; i++)
                        {
                            byte[] tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                            Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
                            byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes, true);
                            // Tenga en cuenta que RSACryptoServiceProvider invierte el orden de bytes cifrados después del cifrado y antes de descifrar.
                            // Si no requiere compatibilidad con Microsoft Cryptographic API (CAPI) y / o con otros proveedores.
                            // Comente la siguiente línea y la correspondiente en la función DecryptString.
                            Array.Reverse(encryptedBytes);
                            // ¿Por qué convertir a la base 64?
                            // Debido a que es la mayor fuente de alimentación de dos impresoras con caracteres ASCII
                            stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
                        }
                        return stringBuilder.ToString();
                    }
                    catch (CryptographicException)
                    { return string.Empty; }
                    catch (Exception)
                    { return string.Empty; }
                }
            }
            else
            { return string.Empty; }

            return null;
        }

        public static string Desencriptar(string Valor, string ClavePrivada)
        {
            try
            {
                if (ClavePrivada == null)
                    return string.Empty;

                if (Valor == null || Valor.Trim().Length == 0)
                    return string.Empty;

                string bitStrengthString = ClavePrivada.Substring(0, ClavePrivada.IndexOf("|") + 1);
                var valuetempkeyPrivate = ClavePrivada.Replace(bitStrengthString, "");
                int bitStrength = Convert.ToInt32(bitStrengthString.Replace("|", ""));

                // TODO: Agregar controladores de excepción adecuados
                RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(bitStrength);
                rsaCryptoServiceProvider.FromXmlString(valuetempkeyPrivate);
                int base64BlockSize = ((bitStrength / 8) % 3 != 0) ? (((bitStrength / 8) / 3) * 4) + 4 : ((bitStrength / 8) / 3) * 4;
                int iterations = Valor.Length / base64BlockSize;
                ArrayList arrayList = new ArrayList();
                for (int i = 0; i < iterations; i++)
                {
                    byte[] encryptedBytes = Convert.FromBase64String(Valor.Substring(base64BlockSize * i, base64BlockSize));
                    // Tenga en cuenta que RSACryptoServiceProvider invierte el orden de bytes cifrados después del cifrado y antes de descifrar.
                    // Si no requiere compatibilidad con Microsoft Cryptographic API (CAPI) y / o con otros proveedores.
                    // Comente la siguiente línea y la correspondiente en la función EncryptString.
                    Array.Reverse(encryptedBytes);
                    arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(encryptedBytes, true));
                }
                return Encoding.UTF32.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
            }
            catch (CryptographicException)
            { return string.Empty; }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }

    public class EncryptRSAValor
    {
        public string Privada { get; set; }
        public string Publica { get; set; }
    }
}
