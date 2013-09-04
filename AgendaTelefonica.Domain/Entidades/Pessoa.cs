using AgendaTelefonica.Domain.Entidades.Interfaces;

namespace AgendaTelefonica.Domain.Entidades
{
    public class Pessoa : IRaizDeAgregacao<int>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}
