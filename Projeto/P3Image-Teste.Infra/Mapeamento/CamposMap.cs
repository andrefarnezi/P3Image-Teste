using FluentNHibernate.Mapping;
using P3Image_Teste.Infra.Objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Image_Teste.Infra.Mapeamento
{
    public class CamposMap: ClassMap<Campos>
    {
        public CamposMap()
        {
            Id(x => x.campoId).GeneratedBy.Identity();
            Map(x => x.descricao).Length(200).Not.Nullable();
            Map(x => x.lista).Length(200);
            Map(x => x.tipo).Not.Nullable();
            Map(x => x.ordem).Not.Nullable();
            References(x => x.subCategoria);
           
        }
    }
}
