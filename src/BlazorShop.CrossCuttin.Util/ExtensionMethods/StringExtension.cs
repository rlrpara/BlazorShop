using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using BlazorShop.CrossCuttin.Util.Criptografia;

namespace BlazorShop.CrossCuttin.Util.ExtensionMethods;

public static class StringExtension
{
    public static string SepararTitulo(this string? valor)
    {
        var texto = "";

        foreach (var item in valor?.ToCharArray().ToList() ?? new List<char>())
            texto += char.IsUpper(item) ? $" {item}" : $"{item}";

        return texto.Trim();
    }
    public static string RemoverAcentos(this string? texto)
    {
        /** Troca os caracteres acentuados por não acentuados **/
        string[] acentos = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
        string[] semAcento = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

        for (int i = 0; i < acentos.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(texto))
                texto = texto.Replace(acentos[i], semAcento[i]);
        }
        /** Troca os caracteres especiais da string por "" **/
        string[] caracteresEspeciais = { "¹", "²", "³", "£", "¢", "¬", "º", "¨", "\"", "'", ":", "(", ")", "ª", "|", "\\\\", "°", "_", "@", "#", "!", "$", "%", "&", "*", ";", "/", "<", ">", "?", "[", "]", "{", "}", "=", "+", "§", "´", "`", "^", "~" };

        for (int i = 0; i < caracteresEspeciais.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(texto))
                texto = texto.Replace(caracteresEspeciais[i], "");
        }

        return texto?.Trim().ToUpper() ?? "";
    }
    public static string ApenasTexto(this string? valor)
        => (valor == null) ? "" : new Regex(@"[^a-zA-Z]", RegexOptions.None, TimeSpan.FromMilliseconds(100)).Replace(valor, "").ToString();
    public static string ApenasNumeros(this string? valor, string valorPadrao = "0")
    {
        if (!string.IsNullOrEmpty(valor?.Trim()))
        {
            var valorAlterado = new Regex(@"[^0-9]", RegexOptions.None, TimeSpan.FromMilliseconds(100)).Replace(valor, "").ToString();
            return string.IsNullOrEmpty(valorAlterado) ? valorPadrao : valorAlterado;
        }
        else
            return "0";
    }
    public static DateTime? DataPadrao(this string valor, string dataPadrao = "01/01/1900")
    {
        if (valor.DataValida())
            return Convert.ToDateTime(string.IsNullOrWhiteSpace(valor) ? dataPadrao : valor);
        else
            return Convert.ToDateTime(string.IsNullOrWhiteSpace(dataPadrao) ? "01/01/1900" : dataPadrao);
    }
    public static bool DataValida(this string? data)
    {
        if (string.IsNullOrWhiteSpace(data))
            return false;

        Regex ok = new(@"(\d{2}\/\d{2}\/\d{4})", RegexOptions.None, TimeSpan.FromMilliseconds(100));

        if (ok.Match(data).Success)
            return DateTime.TryParse(data, out _);

        return ok.Match(data).Success;
    }
    public static bool CpfValido(this string? cpf)
    {
        cpf = cpf.ApenasNumeros();
        if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
            return false;

        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma = 0, resto;
        string tempCpf, digito;

        tempCpf = cpf.Substring(0, 9);
        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        resto = soma % 11;

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();
        tempCpf = tempCpf + digito;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        resto = soma % 11;

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito += resto.ToString();
        return cpf.EndsWith(digito);
    }
    public static bool CnpjValido(this string cnpj)
    {
        cnpj = cnpj.ApenasNumeros();
        if (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14)
            return false;

        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma = 0, resto;
        string digito, tempCnpj;

        tempCnpj = cnpj.Substring(0, 12);
        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
        resto = (soma % 11);

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();
        tempCnpj += digito;

        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
        resto = (soma % 11);

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito += resto.ToString();
        return cnpj.EndsWith(digito);
    }
    public static bool PisValido(this string numeroPis)
    {
        int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma;
        int resto;
        if (numeroPis?.Trim().ApenasNumeros().Length != 11)
            return false;
        numeroPis = numeroPis.Trim();
        numeroPis = numeroPis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(numeroPis[i].ToString()) * multiplicador[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        return numeroPis.EndsWith(resto.ToString());
    }
    public static string AplicarCriptografia(this string valor)
    {
        if (!string.IsNullOrWhiteSpace(valor))
            return new CriptoHash(SHA512.Create()).CriptografarSenha(valor);
        return valor;
    }
    public static string ObterWhereComOperadoresDeComparacaoParaData(this string valor, string nomeCampo)
    {
        //eq 1900-12-20 IGUAL A
        //ge 1900-12-20 MAIOR OU IGUAL A
        //le 1900-12-20 MENOR OU IGUAL A
        //ge 1900-12-10 le 1900-12-20 PERÍODO ENTRE
        string filtro = "";
        valor = valor.ToLower();

        if (valor.Contains("ge") && valor.Contains("le"))
        {
            string dataMenor = (valor.Split("ge", StringSplitOptions.RemoveEmptyEntries).First()?.Trim() ?? "").Split(" ").First();
            if (dataMenor.Contains('/')) dataMenor = dataMenor.DataValida() ? Convert.ToDateTime(dataMenor).ToString("yyyy-MM-dd") : "";

            string dataMaior = (valor.Split("le", StringSplitOptions.RemoveEmptyEntries).Last()?.Trim() ?? "").Split(" ").First();
            if (dataMaior.Contains('/')) dataMaior = dataMaior.DataValida() ? Convert.ToDateTime(dataMaior).ToString("yyyy-MM-dd") : "";

            if (string.IsNullOrEmpty(dataMenor) || string.IsNullOrEmpty(dataMaior))
                filtro = "";
            else if (dataMenor.Split("-").First().Length == 2 || dataMaior.Split("-").First().Length == 2)
                filtro = "";
            else
                filtro = $"CAST({nomeCampo} AS DATE) BETWEEN CAST('{dataMenor}' AS DATE) AND CAST('{dataMaior}' AS DATE)";
        }
        else if (valor.Contains("eq") || valor.Contains("ge") || valor.Contains("le"))
        {
            var operador = valor.Contains("eq") ? "=" : valor.Contains("ge") ? ">=" : "<=";
            string dataValor = valor.Split("eq", StringSplitOptions.RemoveEmptyEntries).Last()?.Trim() ?? "";

            if (!string.IsNullOrEmpty(dataValor) && !dataValor.Contains('/') && dataValor.Split("-").First().Length == 4)
                filtro = $"CAST({nomeCampo} AS DATE) {operador} CAST('{dataValor.Split(" ").First()}' AS DATE)";
            else if (dataValor.DataValida())
                filtro = $"CAST({nomeCampo} AS DATE) {operador} CAST('{Convert.ToDateTime(dataValor):yyyy-MM-dd}' AS DATE)";
            else
                filtro = "";
        }

        return filtro;
    }
    public static string ObterWhereComOperadoresDeComparacaoParaCodigoId(this string valor, string nomeCampo)
    {
        //ot 1,2,3,4,5 CÓDIGOS DIFERENTE DE
        //ge 15 MAIOR OU IGUAL A
        //le 15 MENOR OU IGUAL A
        //ge 5 le 15" CÓDIGOS ENTRE
        valor = valor.ToLower();

        if (valor.Contains("ge") && valor.Contains("le"))
        {
            string valorMenor = (valor.Split("ge", StringSplitOptions.RemoveEmptyEntries).First()?.Trim() ?? "").Split(" ").First();
            string valorMaior = (valor.Split("le", StringSplitOptions.RemoveEmptyEntries).Last()?.Trim() ?? "").Split(" ").First();
            return $"{nomeCampo} BETWEEN {valorMenor} AND {valorMaior})";
        }
        else if (valor.Contains("ot"))
            return $"{nomeCampo} NOT IN ({valor.Replace("ot", "").Trim()})";
        else if (valor.Contains("ge"))
            return $"{nomeCampo} >= ({valor.Replace("ge", "").Trim()})";
        else if (valor.Contains("le"))
            return $"{nomeCampo} <= ({valor.Replace("le", "").Trim()})";

        return string.Empty;
    }
    public static string Base64ToText(this string? base64)
    {
        if (!string.IsNullOrWhiteSpace(base64))
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));

        return string.Empty;
    }
    public static string TextToBase64(this string arquivoOuStringDeDados, bool usarArquivo = true)
    {
        if (usarArquivo && File.Exists(arquivoOuStringDeDados))
        {
            var arquivo = File.ReadAllText(arquivoOuStringDeDados, Encoding.Latin1);
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(Environment.NewLine, arquivo)));
        }
        else if (!usarArquivo)
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(Environment.NewLine, arquivoOuStringDeDados)));

        return string.Empty;
    }
    public static void ConvertBase64ToExcel(this string base64String, string caminhoArquivo)
    {
        File.WriteAllBytes(caminhoArquivo, Convert.FromBase64String(base64String));
    }
    public static string ConvertExcelToBase64(this string caminhoArquivo)
    {
        byte[] fileBytes = File.ReadAllBytes(caminhoArquivo);
        return Convert.ToBase64String(fileBytes);
    }
}
