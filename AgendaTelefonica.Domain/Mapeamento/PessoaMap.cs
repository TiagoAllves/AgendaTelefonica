using AgendaTelefonica.Domain.Entidades;
using FluentNHibernate.Mapping;

namespace AgendaTelefonica.Domain.Mapeamento
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        PessoaMap()
        {
            Id(p => p.Id);
            Map(p => p.Nome);
            Map(p => p.Idade);
            Map(p => p.Telefone);
            Map(p => p.Cpf);
        }
    }
}
