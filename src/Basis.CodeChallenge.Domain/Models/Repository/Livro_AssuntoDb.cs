namespace Basis.CodeChallenge.Domain.Models.Repository
{
    public class Livro_AssuntoDb
    {
        public int Livro_CodL { get; set; }
        public virtual LivroDb CodLivroNavigation { get; set; }
        public int Assunto_CodAs { get; set; }
        public virtual AssuntoDb CodAssuntoNavigation { get; set; }
         
    }
}
