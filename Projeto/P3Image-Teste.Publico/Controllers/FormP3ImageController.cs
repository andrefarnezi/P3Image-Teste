using P3Image_Teste.Infra;
using P3Image_Teste.Infra.Objeto;
using P3Image_Teste.Publico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;

namespace P3Image_Teste.Publico.Controllers
{
    public class FormP3ImageController : Controller
    {
        //
        // GET: /FormP3Image/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Formulario(string slugCategoria, string slugSubCategoria)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var model = new FormP3imageModel();
                var Registro = session.Query<Campos>().ToList().Where(x => x.subCategoria.categoria.slug == slugCategoria && x.subCategoria.slug ==  slugSubCategoria);


                model.Categoria = new Administracao.Models.Categoria {
                    categoriaId = Registro.FirstOrDefault().subCategoria.categoria.categoriaId,
                    descricao = Registro.FirstOrDefault().subCategoria.categoria.descricao,
                    };
                model.Subcategoria = new Administracao.Models.SubCategoria
                {
                    subCategoriaId = Registro.FirstOrDefault().subCategoria.subCategoriaId,
                    descricao = Registro.FirstOrDefault().subCategoria.descricao,
                };
                model.Campos = Registro.Select(x => new Administracao.Models.Camposteste
                {
                    Descricao = x.descricao,
                    Lista = x.lista,
                    Tipo = x.tipo,
                    Ordem = x.ordem
                }).ToList();
                return View(model);
            }
        }
    }
}
