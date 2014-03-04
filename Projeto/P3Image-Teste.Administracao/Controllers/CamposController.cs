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

                    var subCatCampos = campos.Select(item => new CamposModel
                    {
                        campoId = item.campoId,
                        descricao = item.descricao,
                        tipoTexto = Enum.GetName(typeof(TiposCamposEnum), item.tipo),
                        listacheckDrop = item.lista,
                        ordenacao = item.ordem

                    }).ToList();
                    var subCat = session.Get<SubCategoria>(id);
                    SubCategoriaCampos retorno = new SubCategoriaCampos();
                    retorno.listaCampos = subCatCampos.ToList();
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
                subCategoriasEditar.descricao = campo.descricao;
                subCategoriasEditar.ordenacao = campo.ordem;
                subCategoriasEditar.tipoTexto = Enum.GetName(typeof(TiposCamposEnum), campo.tipo);
                subCategoriasEditar.listacheckDrop = campo.lista;
                subCategoriasEditar.subCategoria = new SubCategoriaModel { subCategoriaId = campo.subCategoria.subCategoriaId, descricao = campo.subCategoria.descricao, slug = campo.subCategoria.slug };
                return View(subCategoriasEditar);
            }
        }
        #endregion

        #region Incluir
        public ActionResult Incluir(int id)
        {
            CamposModel model = new CamposModel();
            model.subCategoriaId = id;
            model.tipoItens = Enum.GetValues(typeof(TiposCamposEnum)).Cast<TiposCamposEnum>().Select(o => new SelectListItem
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
                    camposNovo.descricao = campos.descricao;
                    camposNovo.lista = campos.listacheckDrop;
                    camposNovo.tipo = campos.tipo;
                    camposNovo.ordem = session.Query<Campos>().Where(x => x.subCategoria.subCategoriaId == campos.subCategoriaId).Select(x => x.ordem).OrderByDescending(x => x).FirstOrDefault() + 1;
                    camposNovo.subCategoria = session.Get<Infra.Objeto.SubCategoria>(campos.subCategoriaId);
                    session.SaveOrUpdate(camposNovo);
                    transaction.Commit();
                }
                return RedirectToAction("Index", new { id = campos.subCategoriaId });
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
                subCategoriasEditar.descricao = campo.descricao;
                subCategoriasEditar.tipo = campo.tipo;
                subCategoriasEditar.tipoItens = Enum.GetValues(typeof(TiposCamposEnum)).Cast<TiposCamposEnum>().Select(o => new SelectListItem
                {
                    Text = o.ToString(),
                    Value = ((int)o).ToString()
                }).ToList();
                subCategoriasEditar.listacheckDrop = campo.lista;
                subCategoriasEditar.subCategoriaId = campo.subCategoria.subCategoriaId;
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
                    camposEditar.descricao = campos.descricao;
                    camposEditar.lista = campos.listacheckDrop;
                    camposEditar.tipo = campos.tipo;
                    session.SaveOrUpdate(camposEditar);
                    transaction.Commit();
                }
                return RedirectToAction("Index", new { id = campos.subCategoriaId });
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
                subCategoriasEditar.descricao = campo.descricao;
                subCategoriasEditar.ordenacao = campo.ordem;
                subCategoriasEditar.tipoTexto = Enum.GetName(typeof(TiposCamposEnum), campo.tipo);
                subCategoriasEditar.listacheckDrop = campo.lista;
                subCategoriasEditar.subCategoriaId = campo.subCategoria.subCategoriaId;
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
                return RedirectToAction("Index", new { id = campos.subCategoriaId });
            }

        }
        #endregion
    }
}
