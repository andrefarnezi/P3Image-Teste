using P3Image_Teste.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarTabelasBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NHibernateHelper.CriarTabelasBanco();
                Console.WriteLine("Tabelas geradas com sucesso");
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na geração das tabelas:" + ex.InnerException);
            }

        }
    }
}
