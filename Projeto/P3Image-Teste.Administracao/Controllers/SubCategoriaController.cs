using P3Image_Teste.Infra;
using P3Image_Teste.Infra.Objeto;
using System;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using P3Image_Teste.Administracao.Models;
using P3Image_Teste.Infra.Helper;

namespace P3Image_Teste.Administracao.Controllers
{
    public class SubCategoriaController : Controller
    {

        #region Index
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var subCategorias = session.Query<SubCategoria>().ToList();

                    return View(subCategorias.Select(item => new SubCategoriaModel
                    {
                        subCategoriaId = item.subCategoriaId,
                        descricao = item.descricao,
                        slug = item.slug,
                        categoria = new CategoriaModel { categoriaId = item.categoria.categoriaId, descricao = item.categoria.descricao, slug = item.categoria.slug }


                    }).ToList());
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
                    var subCategorias = session.Get<SubCategoria>(id);
                    SubCategoriaModel subCategoriasDetalhes = new SubCategoriaModel();
                    subCategoriasDetalhes.subCategoriaId = subCategorias.subCategoriaId;
                    subCategoriasDetalhes.descricao = subCategorias.descricao;
                    subCategoriasDetalhes.slug = subCategorias.slug;
                    subCategoriasDetalhes.categoria = new CategoriaModel { categoriaId = subCategorias.categoria.categoriaId, descricao = subCategorias.categoria.descricao, slug = subCategorias.categoria.slug };

                    return View(subCategoriasDetalhes);
                }
            }
        }
        #endregion

        #region Incluir
        public ActionResult Incluir()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    IList<Categoria> CatList = session.Query<Categoria>().ToList();

                    var listaCategorias = (from u in CatList.AsEnumerable()
                                           select new SelectListItem
                                           {
                                               Text = u.descricao,
                                               Value = u.categoriaId.ToString()
                                           }).AsEnumerable();

                    ViewBag.ListaDrop = listaCategorias;
                    return View();

                }
            }

        }

        [HttpPost]
        public ActionResult Incluir(SubCategoria subCat)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        SubCategoria subCategoriaNova = new SubCategoria();
                        subCategoriaNova.descricao = subCat.descricao;
                        subCategoriaNova.slug = GerarSlug.GerarSlugTexto(subCat.descricao);
                        subCategoriaNova.categoria = subCat.categoria;

                        session.SaveOrUpdate(subCategoriaNova);
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
                    IList<Categoria> CatList = session.Query<Categoria>().ToList();

                    var listaCategorias = (from u in CatList.AsEnumerable()
                                           select new SelectListItem
                                           {
                                               Text = u.descricao,
                                               Value = u.categoriaId.ToString(),
                                               
                                           }).AsEnumerable();
                    ViewBag.ListaDrop = listaCategorias;
                    var subCategorias = session.Get<SubCategoria>(id);
                    SubCategoriaModel subCategoriasDetalhes = new SubCategoriaModel();
                    subCategoriasDetalhes.subCategoriaId = subCategorias.subCategoriaId;
                    subCategoriasDetalhes.descricao = subCategorias.descricao;
                    subCategoriasDetalhes.slug = subCategorias.slug;
                    subCategoriasDetalhes.categoria = new CategoriaModel { categoriaId = subCategorias.categoria.categoriaId, descricao = subCategorias.categoria.descricao, slug = subCategorias.categoria.slug };

                    return View(subCategoriasDetalhes);
                }
            }
        }

        [HttpPost]
        public ActionResult Editar(int id, SubCategoria subCat)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var subCategoriaEditar = session.Get<SubCategoria>(id);
                        subCategoriaEditar.descricao = subCat.descricao;
                        subCategoriaEditar.slug = GerarSlug.GerarSlugTexto(subCat.descricao);
                        subCategoriaEditar.categoria = subCat.categoria;

                        session.SaveOrUpdate(subCategoriaEditar);
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
                    IList<Categoria> CatList = session.Query<Categoria>().ToList();

                    var listaCategorias = (from u in CatList.AsEnumerable()
                                           select new SelectListItem
                                           {
                                               Text = u.descricao,
                                               Value = u.categoriaId.ToString(),


                                           }).AsEnumerable();
                    ViewBag.ListaDrop = listaCategorias;
                    var subCategorias = session.Get<SubCategoria>(id);
                    SubCategoriaModel subCategoriasDetalhes = new SubCategoriaModel();
                    subCategoriasDetalhes.subCategoriaId = subCategorias.subCategoriaId;
                    subCategoriasDetalhes.descricao = subCategorias.descricao;
                    subCategoriasDetalhes.slug = subCategorias.slug;
                    subCategoriasDetalhes.categoria = new CategoriaModel { categoriaId = subCategorias.categoria.categoriaId, descricao = subCategorias.categoria.descricao, slug = subCategorias.categoria.slug };

                    return View(subCategoriasDetalhes);
                }
            }
        }

        [HttpPost]
        public ActionResult Excluir(int id, SubCategoria subCat)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var subCategoriaDeletar = session.Get<SubCategoria>(id);

                        session.Delete(subCategoriaDeletar);
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

