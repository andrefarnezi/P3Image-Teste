using P3Image_Teste.Infra;
using P3Image_Teste.Infra.Objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using P3Image_Teste.Administracao.Models;
using NHibernate;

namespace P3Image_Teste.Administracao.Controllers
{
    public class CamposController : Controller
    {
        #region Index
        public ActionResult Index(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var campos = session.Query<Campos>().Where(x => x.subCategoria.subCategoriaId == id ).ToList();

                    var teste = campos.Select(item => new Models.CamposModel
                    {
                        CampoId = item.campoId,
                        Descricao = item.descricao,
                        TipoTxt = Enum.GetName(typeof(TiposCamposEnum), item.tipo),
                        Lista = item.lista,
                        Ordem = item.ordem,
                        SubCategoria = new SubCategoriaModel { subCategoriaId = item.subCategoria.subCategoriaId, descricao = item.subCategoria.descricao, slug = item.subCategoria.slug }

                    }).ToList();
                    var subCat = session.Get<Infra.Objeto.SubCategoria>(id);
                    SubCatCampos retorno = new SubCatCampos();
                    retorno.listaCampos = teste.ToList();
                    retorno.SubCategoria = new SubCategoriaModel { subCategoriaId = subCat.subCategoriaId, descricao = subCat.descricao, slug = subCat.slug };
                    return View(retorno);
                }
            }
        }
        #endregion

        #region Detalhes
        public ActionResult Detalhes(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var campo = session.Get<Campos>(id);
                CamposModel subCategoriasEditar = new CamposModel();
                subCategoriasEditar.Descricao = campo.descricao;
                subCategoriasEditar.Ordem = campo.ordem;
                subCategoriasEditar.TipoTxt = Enum.GetName(typeof(TiposCamposEnum), campo.tipo);
                subCategoriasEditar.Lista = campo.lista;
                subCategoriasEditar.SubCategoria = new SubCategoriaModel { subCategoriaId = campo.subCategoria.subCategoriaId, descricao = campo.subCategoria.descricao, slug = campo.subCategoria.slug };
                return View(subCategoriasEditar);
            }
        }
        #endregion

        #region Incluir
        public ActionResult Incluir(int id)
        {
            CamposModel model = new CamposModel();
            model.SubCategoriaId = id;
            model.TipoItens = Enum.GetValues(typeof(TiposCamposEnum)).Cast<TiposCamposEnum>().Select(o => new SelectListItem
            {
                Text = o.ToString(),
                Value = ((int)o).ToString()
            }).ToList();

            return View(model);
        }


        [HttpPost]
        public ActionResult Incluir(CamposModel campos)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Campos camposNovo = new Campos();
                    camposNovo.descricao = campos.Descricao;
                    camposNovo.lista = campos.Lista;
                    camposNovo.tipo = campos.Tipo;
                    camposNovo.ordem = session.Query<Campos>().Where(x => x.subCategoria.subCategoriaId == campos.SubCategoriaId).Select(x => x.ordem).OrderByDescending(x => x).FirstOrDefault() + 1;
                    camposNovo.subCategoria = session.Get<Infra.Objeto.SubCategoria>(campos.SubCategoriaId);
                    session.SaveOrUpdate(camposNovo);
                    transaction.Commit();
                }
                return RedirectToAction("Index", new { id = campos.SubCategoriaId });
            }

        }
        #endregion

        #region Editar
        public ActionResult Editar(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var campo = session.Get<Campos>(id);
                CamposModel subCategoriasEditar= new CamposModel();
                subCategoriasEditar.Descricao = campo.descricao;
                subCategoriasEditar.Tipo = campo.tipo;
                subCategoriasEditar.TipoItens = Enum.GetValues(typeof(TiposCamposEnum)).Cast<TiposCamposEnum>().Select(o => new SelectListItem
                {
                    Text = o.ToString(),
                    Value = ((int)o).ToString()
                }).ToList();
                subCategoriasEditar.Lista = campo.lista;
                subCategoriasEditar.SubCategoriaId = campo.subCategoria.subCategoriaId;
                return View(subCategoriasEditar);
            }
        }


        [HttpPost]
        public ActionResult Editar(int id, CamposModel campos)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var camposEditar = session.Get<Campos>(id);
                    camposEditar.descricao = campos.Descricao;
                    camposEditar.lista = campos.Lista;
                    camposEditar.tipo = campos.Tipo;
                    session.SaveOrUpdate(camposEditar);
                    transaction.Commit();
                }
                return RedirectToAction("Index", new { id = campos.SubCategoriaId });
            }

        }
        #endregion

        #region Excluir
        public ActionResult Excluir(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var campo = session.Get<Campos>(id);
                CamposModel subCategoriasEditar = new CamposModel();
                subCategoriasEditar.Descricao = campo.descricao;
                subCategoriasEditar.Ordem = campo.ordem;
                subCategoriasEditar.TipoTxt = Enum.GetName(typeof(TiposCamposEnum), campo.tipo);
                subCategoriasEditar.Lista = campo.lista;
                subCategoriasEditar.SubCategoriaId = campo.subCategoria.subCategoriaId;
                return View(subCategoriasEditar);
            }
        }

        [HttpPost]
        public ActionResult Excluir(int id, CamposModel campos)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var camposExcluir = session.Get<Campos>(id);
                    session.Delete(camposExcluir);
                    transaction.Commit();
                }
                return RedirectToAction("Index", new { id = campos.SubCategoriaId });
            }

        }
        #endregion
    }
}
