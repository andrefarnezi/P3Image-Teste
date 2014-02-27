using P3Image_Teste.Infra;
using P3Image_Teste.Infra.Objeto;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using System.Collections.Generic;
namespace P3Image_Teste.Administracao.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var categorias = session.Query<Categoria>().ToList();
                    return View(categorias.Select(item => new Models.Categoria
                    {
                        categoriaId = item.categoriaId,
                        descricao = item.descricao,
                        slug = item.slug
                        
                    })
                    );

                }
            }
        }
        public ActionResult Detalhes(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var categoria = session.Get<Categoria>(id);
                    Models.Categoria categoriaDetalhe = new Models.Categoria();
                    categoriaDetalhe.categoriaId = categoria.categoriaId;
                    categoriaDetalhe.descricao = categoria.descricao;
                    categoriaDetalhe.slug = categoria.slug;
                    return View(categoriaDetalhe);
                }
            }

        }
        public ActionResult Editar(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var categoria = session.Get<Categoria>(id);
                    Models.Categoria categoriaDetalhe = new Models.Categoria();
                    categoriaDetalhe.categoriaId = categoria.categoriaId;
                    categoriaDetalhe.descricao = categoria.descricao;
                    categoriaDetalhe.slug = categoria.slug;
                    return View(categoriaDetalhe);
                }
            }

        }

        public ActionResult Excluir(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var categoria = session.Get<Categoria>(id);
                    Models.Categoria categoriaDetalhe = new Models.Categoria();
                    categoriaDetalhe.categoriaId = categoria.categoriaId;
                    categoriaDetalhe.descricao = categoria.descricao;
                    categoriaDetalhe.slug = categoria.slug;
                    return View(categoriaDetalhe);
                }
            }

        }
        public ActionResult Incluir()
        {
                    return View();
        }

       
        [HttpPost]
        public ActionResult Editar(int id, Categoria cat)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        Models.GerarSlug GerarSlug = new Models.GerarSlug();
                        var CategoriaEditar = session.Get<Categoria>(id);
                        CategoriaEditar.descricao = cat.descricao;
                        CategoriaEditar.slug = GerarSlug.GerarSlugTexto(cat.descricao);

                        session.SaveOrUpdate(CategoriaEditar);
                        transaction.Commit();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();

            }

        }
        
        [HttpPost]
        public ActionResult Excluir(int id, Categoria cat)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var CategoriaEditar = session.Get<Categoria>(id);
                        session.Delete(CategoriaEditar);
                        transaction.Commit();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();

            }

        }

        [HttpPost]
        public ActionResult Incluir(Categoria cat)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        Models.GerarSlug GerarSlug = new Models.GerarSlug();
                        Categoria categoriaNova = new Categoria();
                        categoriaNova.descricao = cat.descricao;
                        categoriaNova.slug = GerarSlug.GerarSlugTexto(cat.descricao);

                        session.SaveOrUpdate(categoriaNova);
                        transaction.Commit();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

        }
    }


}

