using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P3Image_Teste.Administracao.Controllers;
using System.Web.Mvc;
using P3Image_Teste.Infra.Objeto;
using P3Image_Teste.Infra.Helper;
using P3Image_Teste.Infra;

namespace P3Image_Teste.Administracao.Tests
{
    [TestClass]
    public class AdministracaoTest
    {
        [TestMethod]
        public void IndexTest()
        {
            var controller = new CategoriaController();
            var result = controller.Index();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IncluirTestView()
        {
            CategoriaController controllerTest = new CategoriaController();

            ViewResult result = controllerTest.Incluir() as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void IncluirCategoriaTest()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Categoria categoriaIncluir = new Categoria();
                    categoriaIncluir.descricao = "descricao";
                    categoriaIncluir.slug = GerarSlug.GerarSlugTexto("descricao");
                    session.SaveOrUpdate(categoriaIncluir);

                }
            }

        }

    }
}
