﻿using Basis.CodeChallenge.Domain.Interfaces.Repository;
using Basis.CodeChallenge.Domain.Models.Repository;
using Basis.CodeChallenge.Infra.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basis.CodeChallenge.Infra.Repository
{
    public class LivroRepository : EntityBaseRepository<LivroDb>, IBasisLivroRepository
    {
        private readonly DapperContext _dapperContext;
        private readonly EntityContext _entityContext;

        public LivroRepository(EntityContext context, DapperContext dapperContext)
            : base(context)
        {
            _dapperContext = dapperContext;
            _entityContext= context;
        }

        public async Task<IEnumerable<LivroDb>> GetAllAsync()
        {
            var query = @$"SELECT {nameof(LivroDb.CodL)}, {nameof(LivroDb.Titulo)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.Edicao)}, {nameof(LivroDb.AnoPublicacao)}, DateCreated
                            FROM LivroDb c";
            using (var connection = _dapperContext.DapperConnection)
            {
                var livros = await connection.QueryAsync<LivroDb, long, LivroDb>(
                    query,
                    (livro, dateCreated) =>
                    {
                        livro.DateCreated = DateTimeOffset.FromUnixTimeSeconds(dateCreated).DateTime;
                        return livro;
                    },
                    splitOn: "DateCreated"
                );
                return livros;
            }
         }


        public async Task<LivroDb> GetByTituloAsync(string titulo)
        {
            var query = @$"SELECT {nameof(LivroDb.CodL)}, {nameof(LivroDb.Titulo)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.AnoPublicacao)}, DateCreated
                            FROM LivroDb
                          WHERE {nameof(LivroDb.Titulo)} = @Titulo";

            return (await _dapperContext.DapperConnection.QueryAsync<LivroDb>(query, new { Titulo = titulo })).FirstOrDefault();
        }
        public async Task<LivroDb> GetByEditoralAsync(string editora)
        {
            var query = @$"SELECT {nameof(LivroDb.CodL)}, {nameof(LivroDb.Titulo)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.Editora)}, {nameof(LivroDb.AnoPublicacao)}, DateCreated
                            FROM LivroDb
                          WHERE {nameof(LivroDb.Editora)} = @Editora";

            return (await _dapperContext.DapperConnection.QueryAsync<LivroDb>(query, new { Editora = editora })).FirstOrDefault();
        }

        public async Task<LivroDb> GetByIdAsync(int id)
        {       
            return await  _entityContext.Livro.AsNoTracking().FirstOrDefaultAsync(x=>x.CodL==id); 
        }
    }
}
