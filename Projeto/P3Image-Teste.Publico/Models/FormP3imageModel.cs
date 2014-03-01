using P3Image_Teste.Administracao.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P3Image_Teste.Publico.Models
{
    public class FormP3imageModel
    {
        [Display(Name = "Categoria")]
        public virtual CategoriaModel Categoria { get; set; }

        [Display(Name = "Subcategoria")]
        public virtual SubCategoriaModel Subcategoria { get; set; }

        [Display(Name = "Campos")]
        public virtual List<CamposModel> Campos { get; set; }

        public virtual bool TemRegistros { get; set; }
    }
}