using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P3Image_Teste.Administracao.Models
{
    public class CategoriaModel
    {
        [Display(Name = "Id")]
        public virtual int categoriaId { get; set; }

        [Required(ErrorMessage = "Favor Preencher Campo: Descrição")]
        [Display(Name = "Descrição")]
        public virtual string descricao { get; set; }

        [Required(ErrorMessage = "Favor Preencher Campo: Slug")]
        [Display(Name = "Slug")]
        public virtual string slug { get; set; }
    }
}