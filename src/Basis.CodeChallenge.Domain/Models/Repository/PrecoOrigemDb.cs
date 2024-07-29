using System;

namespace Basis.CodeChallenge.Domain.Models.Repository
{
    public class PrecoOrigemDb
    {
        public int CoPo { get; set; }
        public int Livro_CodL { get; set; }
        public string Origem { get; set; }
        public int Valor { get; set; } //centavos

        public LivroDb CodLivroNavigationLivro { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
