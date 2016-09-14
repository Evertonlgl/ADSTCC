using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Class1
/// vetor de representação de inteiros 
/// utilizado para a criptografia (chave externa)
/// </summary>
public class criptografia{
    private static byte[] biV = {0x50, 0x08, 0xf1, 0xDD , 0xDE , 0x3C , 0xF2 , 0x18, 0x44, 0x74,0x19, 0x2C, 0x53, 0x49 , 0xAB , 0xBC };

    /// <summary>
    /// representação de valor em base64(co m sua chave maxima de caracter). Seria: 8 *32=256bits
    /// algoritmo RINJNDAEL ou AES
    /// </summary>
    private const string cryptoKey= "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";
    
    /// <summary>
    /// criptografa o valor 
    /// </summary>
    /// <param name="texto">o que você quer criptografar</param>
    /// <returns></returns>
 

    public static string EncodeRijndael(string texto){
        try{
        // Se a string não esta vazia,executa a criptografia
            if (!string.IsNullOrEmpty(texto))
            {
                // cria instancias de vetores de bytes com as chaves
                byte[] bkey = Convert.FromBase64String(cryptoKey);
                byte[] bTexto = new UTF8Encoding().GetBytes(texto);
                // Instancia a classe a classe de criptografia RINJNDAEL
                Rijndael rijndael = new RijndaelManaged();
                //Define tamanho da chave  256 = 8*32
                //Lembre-se :
                //128(16 caracteres), 192(24 caracteres), 256 (32 caracteres)
                rijndael.KeySize = 256;
                // criar o espaço de memoria para guardar o valor criptografado:

                MemoryStream mStream = new MemoryStream();
                // instanciou o encriptador

                CryptoStream encryptor = new CryptoStream(mStream, rijndael.CreateEncryptor(bkey, biV), CryptoStreamMode.Write);

                //Faz a escrita dos dados criptografados no espaço de memoria 
                encryptor.Write(bTexto, 0, bTexto.Length);
                //Despeja toda a memoria
                encryptor.FlushFinalBlock();
                //pega o vetor de bytes da memoria e gera a string criptografada
                return Convert.ToBase64String(mStream.ToArray());

            }//fim do if
            else{
                // se a string for vazia retorna null
                return null;
            }
        }// fim do try
        catch(Exception e) {
            // se ocorrer um erro , dispara a exceção 
            throw new ApplicationException("Erro ao criptografar", e);


        }//fim catch
    }//metodo

    
    public static string Decrypty(string text)
    {
        try
        {
            text.Replace(' ', '+');
            if (!string.IsNullOrWhiteSpace(text))
            {
                //cria instacia de vetores de byte com as chaves
                byte[] bkey = Convert.FromBase64String(cryptoKey);

                byte[] btext = Convert.FromBase64String(text);

                //instanciar p rijn
                Rijndael rijndael = new RijndaelManaged();

                //difinição de tamanh da chave....
                rijndael.KeySize = 256;

                //criar o espaço em memória 

                MemoryStream mSteam = new MemoryStream();

                //instancia o "decriptador"
                CryptoStream decryptor = new CryptoStream(mSteam, rijndael.CreateDecryptor(bkey, biV), CryptoStreamMode.Write);

                decryptor.Write(btext, 0, btext.Length);
                //despejado a memoria

                //instanciando a classe utf8
                decryptor.FlushFinalBlock();

                UTF8Encoding utf8 = new UTF8Encoding();

                return utf8.GetString(mSteam.ToArray());

                //else do if da string vazia


            }
            else
            {
                return null;
            }
        }// fim do try 

        catch (Exception ex) { throw new ApplicationException("Erro ao descriptografar", ex); }
    }
}