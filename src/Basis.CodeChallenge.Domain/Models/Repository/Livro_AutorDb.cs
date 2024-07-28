namespace Basis.CodeChallenge.Domain.Models.Repository
{
    public class Livro_AutorDb
    {    
        public int Livro_CodL { get;  set; }
        public virtual LivroDb CodLivroNavigation { get; set; }
        public int Autor_CodAu { get;  set; }
        public virtual AutorDb CodAutorNavigation { get; set; }
    }
}
