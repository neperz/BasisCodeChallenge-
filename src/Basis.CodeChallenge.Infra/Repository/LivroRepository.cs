using Basis.CodeChallenge.Domain.Interfaces.Repository;
using Basis.CodeChallenge.Domain.Models.Repository;
using Basis.CodeChallenge.Infra.Context;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basis.CodeChallenge.Infra.Repository
{
    public class LivroRepository : EntityBaseRepository<LivroDb>, IBasisLivroRepository
    {
        private readonly DapperContext _dapperContext;

        public LivroRepository(EntityContext context, DapperContext dapperContext)
            : base(context)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<LivroDb>> GetAllAsync()
        {
            var query = @$"SELECT {nameof(LivroDb.CodL)}, {nameof(LivroDb.Titulo)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.AnoPublicacao)}, DateCreated
                            FROM Livro c";

            return await _dapperContext.DapperConnection.QueryAsync<LivroDb>(query, null, null, null, null);
        }


        public async Task<LivroDb> GetByTituloAsync(string titulo)
        {
            var query = @$"SELECT {nameof(LivroDb.CodL)}, {nameof(LivroDb.Titulo)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.AnoPublicacao)}, DateCreated
                            FROM Livro
                          WHERE {nameof(LivroDb.Titulo)} = @Titulo";

            return (await _dapperContext.DapperConnection.QueryAsync<LivroDb>(query, new { Titulo = titulo })).FirstOrDefault();
        }
        public async Task<LivroDb> GetByEditoralAsync(string editora)
        {
            var query = @$"SELECT {nameof(LivroDb.CodL)}, {nameof(LivroDb.Titulo)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.AnoPublicacao)}, DateCreated
                            FROM Livro
                          WHERE {nameof(LivroDb.Editora)} = @Editora";

            return (await _dapperContext.DapperConnection.QueryAsync<LivroDb>(query, new { Editora = editora })).FirstOrDefault();
        }

        public async Task<LivroDb> GetByIdAsync(int id)
        {
            var query = @$"SELECT {nameof(LivroDb.CodL)}, {nameof(LivroDb.Titulo)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.AnoPublicacao)}, DateCreated
                            FROM Livro
                          WHERE {nameof(LivroDb.CodL)} = @Id";

            return (await _dapperContext.DapperConnection.QueryAsync<LivroDb>(query, new { Id = id })).FirstOrDefault();
        }
    }
}
