using Basis.CodeChallenge.Domain.Models.Repository;

namespace Basis.CodeChallenge.Domain.Models;

public class PrecoOrigem
{
    public int CoPo { get; set; }
    public int Livro_CodL { get; set; }
    public string Origem { get; set; }
    public int Valor { get; set; } //centavos

    public Livro Livro { get; set; }
}



