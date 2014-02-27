using FluentNHibernate.Mapping;
using P3Image_Teste.Infra.Objeto;

namespace P3Image_Teste.Infra.Mapeamento
{
    public class CategoriaMap: ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Id(x => x.categoriaId).GeneratedBy.Identity(); 
            Map(x => x.descricao).Length(200).Not.Nullable();
            Map(x => x.slug).Length(150).Not.Nullable();
            HasMany(m => m.subCategoria);

        }
    }
}
