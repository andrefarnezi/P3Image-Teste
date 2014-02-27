
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using P3Image_Teste.Infra.Objeto;

namespace P3Image_Teste.Infra
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }
        public static void CriarTabelasBanco()
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(x => x.FromConnectionStringWithKey("Conexao")).ShowSql())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Categoria>());

            configuration.BuildSessionFactory();
        }
      
            public static ISessionFactory CreateSessionFactory()
            {
                FluentConfiguration configuration = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                       x => x.FromConnectionStringWithKey("Conexao")).ShowSql())
                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Categoria>());

                return configuration.BuildSessionFactory();
            }
        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                       x => x.FromConnectionStringWithKey("Conexao")).ShowSql())
                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Categoria>())
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }


        
    }
}
