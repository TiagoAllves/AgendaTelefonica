using AgendaTelefonica.Domain.Entidades;
using FluentNHibernate.Mapping;

namespace AgendaTelefonica.Domain.Mapeamento
{
    public class EnderecoMap : ClassMap<Endereco>
    {
        EnderecoMap()
        {
            Id(e => e.Id);
            Map(e => e.Rua);
            Map(e => e.Numero);
            Map(e => e.Bairro);
            Map(e => e.Cidade);
            Map(e => e.Estado);
            Map(e => e.Pais);
        }
    }
}
