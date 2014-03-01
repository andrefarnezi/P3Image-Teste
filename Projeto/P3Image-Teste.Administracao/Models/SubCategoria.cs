using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P3Image_Teste.Administracao.Models
{
    public class SubCategoriaModel
    {
        [Required]
        public virtual int subCategoriaId { get; set; }

           [Required(ErrorMessage = "Favor Preencher Campo: Descrição")]
        public virtual string descricao { get; set; }

        [Required(ErrorMessage = "Favor Preencher Campo: Slug")]
        public virtual string slug { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public virtual int CategoriaId { get; set; }

        [Required]
        public virtual CategoriaModel categoria { get; set; }

    }
}