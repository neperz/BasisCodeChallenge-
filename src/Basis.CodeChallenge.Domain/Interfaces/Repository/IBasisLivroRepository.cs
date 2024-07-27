using Basis.CodeChallenge.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.CodeChallenge.Domain.Interfaces.Repository;

public interface IBasisLivroRepository : IEntityBaseRepository<Livro>, IDapperReadRepository<Livro>
{
    Task<Livro> GetByTituloAsync(string titulo);
    Task<Livro> GetByEditoralAsync(string editora);
    Task<IEnumerable<Livro>> GetAllAsync();
}
