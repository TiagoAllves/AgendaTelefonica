using AgendaTelefonica.Domain.Entidades;
using NHibernate.Criterion;
using System.Collections.Generic;

namespace AgendaTelefonica.Domain.Repositorio
{
    public class Pessoas : RepositorioBase
    {
        public void Salvar(Pessoa pessoa)
        {
            base.Save(pessoa);
        }

        public void Apagar(Pessoa pessoa)
        {
            base.Delete(pessoa);
        }

        public IList<Pessoa> Todas()
        {
            return base.All<Pessoa>();
        }

        public Pessoa Obter(int id)
        {
            return base.Get<Pessoa>(id);
        }

        public IList<Pessoa> ObterPor(string nome)
        {
            var criterio = Session.CreateCriteria<Pessoa>();
            criterio.Add(Restrictions.Like("Nome", nome));
            return criterio.List<Pessoa>();
        }

    }
}
