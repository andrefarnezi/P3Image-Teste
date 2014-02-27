using System.Collections.Generic;
namespace P3Image_Teste.Infra.Objeto
{
    public class Categoria
    {
        public virtual int categoriaId
        { get; set; }

        public virtual string descricao
        { get; set; }

        public virtual string slug
        { get; set; }


        public virtual IList<SubCategoria> subCategoria { get; set; }

      

    }
}
