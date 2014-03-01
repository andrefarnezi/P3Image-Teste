using P3Image_Teste.Infra;
using P3Image_Teste.Infra.Objeto;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using System.Collections.Generic;
using P3Image_Teste.Administracao.Models;
using P3Image_Teste.Infra.Helper;
namespace P3Image_Teste.Administracao.Controllers
{
    public class CategoriaController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var categorias = session.Query<Categoria>().ToList();
                    return View(categorias.Select(item => new CategoriaModel
                    {
                        categoriaId = item.categoriaId,
                        descricao = item.descricao,
                        slug = item.slug
                        
                    })
                    );

                }
            }
        }
        #endregion 

        #region Detalhes
        public ActionResult Detalhes(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var categoria = session.Get<Categoria>(id);
                    CategoriaModel categoriaDetalhe = new CategoriaModel();
                    categoriaDetalhe.categoriaId = categoria.categoriaId;
                    categoriaDetalhe.descricao = categoria.descricao;
                    categoriaDetalhe.slug = categoria.slug;
                    return View(categoriaDetalhe);
                }
            }

        }
        #endregion

        #region Incluir
        public ActionResult Incluir()
        {
            return View();
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
        #endregion

        #region Editar
        public ActionResult Editar(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var categoria = session.Get<Categoria>(id);
                    CategoriaModel categoriaDetalhe = new CategoriaModel();
                    categoriaDetalhe.categoriaId = categoria.categoriaId;
                    categoriaDetalhe.descricao = categoria.descricao;
                    categoriaDetalhe.slug = categoria.slug;
                    return View(categoriaDetalhe);
                }
            }

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
        #endregion

        #region Excluir
        public ActionResult Excluir(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var categoria = session.Get<Categoria>(id);
                    CategoriaModel categoriaDetalhe = new CategoriaModel();
                    categoriaDetalhe.categoriaId = categoria.categoriaId;
                    categoriaDetalhe.descricao = categoria.descricao;
                    categoriaDetalhe.slug = categoria.slug;
                    return View(categoriaDetalhe);
                }
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
        #endregion

    }
}

