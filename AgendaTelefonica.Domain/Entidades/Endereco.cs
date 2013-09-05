using AgendaTelefonica.Domain.Entidades.Interfaces;

namespace AgendaTelefonica.Domain.Entidades
{
    public class Endereco : IRaizDeAgregacao<int>
    {
        public virtual int Id { get; set; }
        public virtual string Rua { get; set; }
        public virtual int Numero { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual string Pais { get; set; }
    }
}
