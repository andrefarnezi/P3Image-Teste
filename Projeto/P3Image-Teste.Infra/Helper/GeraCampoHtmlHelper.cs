using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Image_Teste.Infra.Helper
{
    public static class GeraCampoHtmlHelper
    {
        public static string GerarCampo(int tipoCampo, int campoId, string descricao, string lista)
        {
            string campo = "";
            if (tipoCampo == 1)
            {
                campo = "<input type = 'text' id = '" + campoId + "' size = '20' />";
            }
            else if (tipoCampo == 2)
            {
                campo = "<textarea id = '" + campoId + "'></textarea>";
            }
            else if (tipoCampo == 3)
            {
                if (!string.IsNullOrEmpty(lista))
                {
                    foreach (string item in lista.Split(';'))
                    {
                        campo = campo + "<input type='checkbox' id='" + campoId + "' value='" + item + "' />" + item;
                    }
                }
            }
            else if (tipoCampo == 4)
            {
                campo = "<select id='" + campoId + "'>";
                if (!string.IsNullOrEmpty(lista))
                {
                    foreach (string item in lista.Split(';'))
                    {
                        campo = campo + "<option value='" + item + "'>" + item + "</option>";
                    }
                }
                campo = campo + "</select>";
            }

            return campo;
        }
    }
}
