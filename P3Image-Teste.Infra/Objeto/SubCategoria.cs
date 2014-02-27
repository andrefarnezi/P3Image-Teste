using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Image_Teste.Infra.Objeto
{
    public class SubCategoria
    {
        public virtual int subCategoriaId { get; set; }

        public virtual string descricao { get; set; }

        public virtual string slug { get; set; }

        public virtual Categoria categoria { get; set; }

      

    }
}
