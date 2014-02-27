using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace P3Image_Teste.Administracao.Models
{
    public class GerarSlug
    {
        public string GerarSlugTexto(string texto)
        {
            String Valor = texto.Normalize(NormalizationForm.FormD).Trim();
            StringBuilder builder = new StringBuilder();

            foreach (char c in texto.ToCharArray())
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);

            Valor = builder.ToString();

            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(texto);

            Valor = Regex.Replace(Regex.Replace(Encoding.ASCII.GetString(bytes), @"\s{2,}|[^\w]", " ", RegexOptions.ECMAScript).Trim(), @"\s+", "-");
            return Valor;
        }
    }
}