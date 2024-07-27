using Dapper;
using Basis.CodeChallenge.Domain.Interfaces.Repository;
using Basis.CodeChallenge.Domain.Models;
using Basis.CodeChallenge.Infra.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basis.CodeChallenge.Infra.Repository
{
    public class LivroRepository : EntityBaseRepository<Livro>, IBasisLivroRepository
    {
        private readonly DapperContext _dapperContext;

        public LivroRepository(EntityContext context, DapperContext dapperContext)
            : base(context)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Livro>> GetAllAsync()
        {
            var query = @$"SELECT {nameof(Livro.CodL)}, {nameof(Livro.Titulo)}, {nameof(Livro.Editora)}, {nameof(Livro.Editora)}, {nameof(Livro.AnoPublicacao)}, DateCreated
                            FROM Livro c";

            return await _dapperContext.DapperConnection.QueryAsync<Livro>(query, null, null, null, null);
        }
 

        public async Task<Livro> GetByTituloAsync(string titulo)
        {
            var query = @$"SELECT {nameof(Livro.CodL)}, {nameof(Livro.Titulo)}, {nameof(Livro.Editora)}, {nameof(Livro.Editora)}, {nameof(Livro.AnoPublicacao)}, DateCreated
                            FROM Livro
                          WHERE {nameof(Livro.Titulo)} = @Titulo";

            return (await _dapperContext.DapperConnection.QueryAsync<Livro>(query, new { Titulo = titulo })).FirstOrDefault();
        }
        public async Task<Livro> GetByEditoralAsync(string editora)
        {
            var query = @$"SELECT {nameof(Livro.CodL)}, {nameof(Livro.Titulo)}, {nameof(Livro.Editora)}, {nameof(Livro.Editora)}, {nameof(Livro.AnoPublicacao)}, DateCreated
                            FROM Livro
                          WHERE {nameof(Livro.Editora)} = @Editora";

            return (await _dapperContext.DapperConnection.QueryAsync<Livro>(query, new { Editora = editora })).FirstOrDefault();
        }

        public async Task<Livro> GetByIdAsync(int id)
        {
            var query = @$"SELECT {nameof(Livro.CodL)}, {nameof(Livro.Titulo)}, {nameof(Livro.Editora)}, {nameof(Livro.Editora)}, {nameof(Livro.AnoPublicacao)}, DateCreated
                            FROM Livro
                          WHERE {nameof(Livro.CodL)} = @Id";

            return (await _dapperContext.DapperConnection.QueryAsync<Livro>(query, new { Id = id })).FirstOrDefault();
        }
    }
}
