using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P3Image_Teste.Administracao.Models
{
    public class CamposModel
    {
        [Display(Name = "Id")]
        public virtual int campoId { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public virtual string descricao { get; set; }

        [Required]
        [Display(Name = "Subcategoria")]
        public virtual int subCategoriaId { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public virtual int tipo { get; set; }

        [Display(Name = "Tipo")]
        public virtual string tipoTexto { get; set; }

        [Display(Name = "Lista")]
        public virtual string listacheckDrop { get; set; }

        [Required]
        [Display(Name = "Ordem")]
        public virtual int ordenacao { get; set; }

        [Display(Name = "Subcategoria")]
        public virtual SubCategoriaModel subCategoria { get; set; }

        public virtual List<SelectListItem> tipoItens { get; set; } 
    }
    public class SubCategoriaCampos
    {
        public List<CamposModel> listaCampos { get; set; }
        public SubCategoriaModel SubCategoria { get; set; }
    }

    public enum TiposCamposEnum
    {
        TextBox = 1,
        TextArea = 2,
        Select = 4,
        Checkbox = 3
    }
}