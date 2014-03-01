using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Image_Teste.Infra.Helper
{
    public static class GerarHtml
    {
        public static string GerarCampoHTML(int tipoCampo, int campoId, string lista)
        {
            string campoFinal = string.Empty;
            switch (tipoCampo)
            {
                case 1:
                    campoFinal = "<input type = 'text' id = '" + campoId + "' size = '25' />";
                break;

                case 2:
                    campoFinal = "<textarea id = '" + campoId + "'></textarea>";
                break;

                case 3:
                    foreach (string item in lista.Split(';'))
                    {
                        campoFinal = campoFinal + "<input type='checkbox' id='" + campoId + "' value='" + item + "' />" + item;
                    }
                break;

                case 4:
                    campoFinal = "<select id='" + campoId + "'>";
                    foreach (string item in lista.Split(';'))
                    {
                        campoFinal = campoFinal + "<option value='" + item + "'>" + item + "</option>";
                    }
                    campoFinal = campoFinal + "</select>";
                break;

            }
            return campoFinal;
        }
    }
}
