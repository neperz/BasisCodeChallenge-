using Basis.CodeChallenge.Domain.Models;
using Basis.CodeChallenge.Domain.Models.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.CodeChallenge.Domain.Interfaces.Repository;

public interface IBasisLivroRepository : IEntityBaseRepository<LivroDb>, IDapperReadRepository<LivroDb>
{
    Task<LivroDb> GetByTituloAsync(string titulo);
    Task<LivroDb> GetByEditoralAsync(string editora);
    Task<IEnumerable<LivroDb>> GetAllAsync();
}
