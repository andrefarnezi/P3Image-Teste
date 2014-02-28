using FluentNHibernate.Mapping;
using P3Image_Teste.Infra.Objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Image_Teste.Infra.Mapeamento
{
    public class SubCategoriaMap : ClassMap<SubCategoria>
    {
        public SubCategoriaMap()
        {
            Id(x => x.subCategoriaId).GeneratedBy.Identity();
            Map(x => x.descricao).Length(200).Not.Nullable();
            Map(x => x.slug).Length(150).Not.Nullable();
            HasMany(m => m.campos);
            References(x => x.categoria);
           
        }
    }
}
