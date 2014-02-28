using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Image_Teste.Infra.Objeto
{
    public class Campos
    {
        public virtual int campoId
        { get; set; }

        public virtual string descricao
        { get; set; }

        public virtual int tipo
        { get; set; }

        public virtual string lista
        { get; set; }

        public virtual int ordem
        { get; set; }

        public virtual SubCategoria subCategoria { get; set; }


    }
}
