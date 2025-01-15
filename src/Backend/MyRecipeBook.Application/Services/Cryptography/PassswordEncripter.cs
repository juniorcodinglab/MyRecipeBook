using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Application.Services.Cryptography;

public class PassswordEncripter
{
    public string Encrypt(string password)
    {
        var chaveAdicional = "ABC";
        var newPassword = $"{password} {chaveAdicional}";

        var bytes = Encoding.UTF8.GetBytes(password);
        var hashBytes = SHA512.HashData(bytes);

        return StringByter(hashBytes);
    }

    private static string StringByter(byte[] bytes)
    {
        var sb = new StringBuilder();

        /* Gerando um Array de Bytes em String */
        foreach (byte b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }

        return sb.ToString();
    }
}


