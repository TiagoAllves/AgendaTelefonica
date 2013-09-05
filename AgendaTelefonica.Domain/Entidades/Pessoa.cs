using AgendaTelefonica.Domain.Entidades.Interfaces;

namespace AgendaTelefonica.Domain.Entidades
{
    public class Pessoa : IRaizDeAgregacao<int>
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual int Idade { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Telefone { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
