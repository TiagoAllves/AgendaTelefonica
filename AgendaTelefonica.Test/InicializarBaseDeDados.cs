using AgendaTelefonica.Domain.Mapeamento;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using NUnit.Framework;

namespace AgendaTelefonica.Test
{
    [TestFixture]
    public class InicializarBaseDeDados
    {
        private void BuildScherma(Configuration config)
        {
            new SchemaExport(config).Drop(true, true);

            new SchemaExport(config)
                .Create(true, true);
        }

        [Test]
        public void Criar_banco_de_dados_pelo_modelo()
        {
            try
            {
                Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(
                    c => c.FromAppSetting("connection")).ShowSql()).Mappings(m => m.FluentMappings.AddFromAssemblyOf<PessoaMap>()).
                    Mappings(m => m.MergeMappings()).ExposeConfiguration(BuildScherma).BuildSessionFactory();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
