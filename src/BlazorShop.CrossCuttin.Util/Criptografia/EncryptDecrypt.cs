﻿using System.Security.Cryptography;
using System.Text;

namespace BlazorShop.CrossCuttin.Util.Criptografia;

public class EncryptDecrypt
{
    public byte[] Key { get; set; }
    public byte[] IniVetor { get; set; }
    public Aes Algorithm { get; set; }

    public EncryptDecrypt()
    {
        this.Key = new byte[] { 12, 2, 56, 117, 5, 67, 55, 23, 12, 2, 88, 139, 12, 67, 91, 23 };
        this.IniVetor = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        this.Algorithm = Aes.Create();
    }

    public string Encrypt(string entryText)
    {
        byte[] symEncryptedData;

        var dataToProtectAsArray = Encoding.UTF8.GetBytes(entryText);
        using (var encryptor = this.Algorithm.CreateEncryptor(this.Key, this.IniVetor))
        using (var memoryStream = new MemoryStream())
        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        {
            cryptoStream.Write(dataToProtectAsArray, 0, dataToProtectAsArray.Length);
            cryptoStream.FlushFinalBlock();
            symEncryptedData = memoryStream.ToArray();
        }
        this.Algorithm.Dispose();
        return Convert.ToBase64String(symEncryptedData);
    }

    public string Decrypt(string entryText)
    {
        var symEncryptedData = Convert.FromBase64String(entryText);
        byte[] symUnencryptedData;
        using (var decryptor = this.Algorithm.CreateDecryptor(this.Key, this.IniVetor))
        using (var memoryStream = new MemoryStream())
        using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write))
        {
            cryptoStream.Write(symEncryptedData, 0, symEncryptedData.Length);
            cryptoStream.FlushFinalBlock();
            symUnencryptedData = memoryStream.ToArray();
        }
        this.Algorithm.Dispose();
        return Encoding.Default.GetString(symUnencryptedData);
    }
}
