using GerenciadorMongo.Dominio.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GerenciadorMongo.Data.Repositorio
{
    public class Repositorio<TContexto> : IRepositorio where TContexto : IContexto
    {
        protected readonly TContexto contexto;

        public Repositorio(TContexto contexto)
        {
            this.contexto = contexto;
        }

        protected virtual IMongoQueryable<TEntidade> ObterQueryable<TEntidade>(
        Expression<Func<TEntidade, bool>> filtro = null,
        Func<IMongoQueryable<TEntidade>, IOrderedMongoQueryable<TEntidade>> ordenarPor = null,
        int? skip = null,
        int? take = null)
        where TEntidade : class, IEntidade, new()
        {

            IMongoQueryable<TEntidade> query = contexto.Set<TEntidade>().AsQueryable();

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            if (ordenarPor != null)
            {
                query = ordenarPor(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        #region CRUD    
        public virtual void Criar<TEntidade>(TEntidade entidade, string criadoPor) where TEntidade : class, IEntidade, new()
        {
            entidade.DataCriacao = DateTime.Now;
            entidade.CriadoPor = criadoPor;
            contexto.Set<TEntidade>().InsertOne(entidade);
        }

        public virtual Task CriarAsync<TEntidade>(TEntidade entidade, string criadoPor) where TEntidade : class, IEntidade, new()
        {
            entidade.DataCriacao = DateTime.Now;
            entidade.CriadoPor = criadoPor;
            return contexto.Set<TEntidade>().InsertOneAsync(entidade);
        }

        public virtual void Atualizar<TEntidade>(TEntidade entidade, string modificadoPor) where TEntidade : class, IEntidade, new()
        {
            entidade.DataModificacao = DateTime.Now;
            entidade.ModificadoPor = modificadoPor;
            contexto.Set<TEntidade>().ReplaceOne(c => c.Id == entidade.Id, entidade);
        }

        public virtual Task AtualizarAsync<TEntidade>(TEntidade entidade, string modificadoPor) where TEntidade : class, IEntidade, new()
        {
            entidade.DataModificacao = DateTime.Now;
            entidade.ModificadoPor = modificadoPor;
            return contexto.Set<TEntidade>().ReplaceOneAsync(c => c.Id == entidade.Id, entidade);
        }

        public virtual void Deletar<TEntidade>(ObjectId id) where TEntidade : class, IEntidade, new()
        {
            contexto.Set<TEntidade>().DeleteOne(c => c.Id == id);
        }

        public virtual Task DeletarAsync<TEntidade>(ObjectId id) where TEntidade : class, IEntidade, new()
        {
            return contexto.Set<TEntidade>().DeleteOneAsync(c => c.Id == id);
        }

        #endregion

        #region Querys
        public virtual IEnumerable<TEntidade> ObterTodos<TEntidade>(Expression<Func<TEntidade, bool>> filtro, Func<IMongoQueryable<TEntidade>, IOrderedMongoQueryable<TEntidade>> ordenarPor, int? skip, int? take) where TEntidade : class, IEntidade, new()
        {
            return ObterQueryable<TEntidade>(filtro, ordenarPor, skip, take).ToList();
        }

        public virtual async Task<IEnumerable<TEntidade>> ObterTodosAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro, Func<IMongoQueryable<TEntidade>, IOrderedMongoQueryable<TEntidade>> ordenarPor, int? skip, int? take) where TEntidade : class, IEntidade, new()
        {
            return await ObterQueryable<TEntidade>(filtro, ordenarPor, skip, take).ToListAsync();
        }

        public virtual bool ObterExistente<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : class, IEntidade, new()
        {
            return ObterQueryable<TEntidade>(filtro).Any();
        }

        public virtual Task<bool> ObterExistenteAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : class, IEntidade, new()
        {
            return ObterQueryable<TEntidade>(filtro).AnyAsync();
        }

        public virtual TEntidade ObterPorId<TEntidade>(ObjectId id) where TEntidade : class, IEntidade, new()
        {
            return contexto.Set<TEntidade>().Find(c => c.Id == id).FirstOrDefault();
        }

        public async virtual Task<TEntidade> ObterPorIdAsync<TEntidade>(ObjectId id) where TEntidade : class, IEntidade, new()
        {
            return await contexto.Set<TEntidade>().Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public virtual TEntidade ObterPrimeiro<TEntidade>(Expression<Func<TEntidade, bool>> filtro, Func<IMongoQueryable<TEntidade>, IOrderedMongoQueryable<TEntidade>> ordenarPor) where TEntidade : class, IEntidade, new()
        {
            return ObterQueryable<TEntidade>(filtro, ordenarPor).FirstOrDefault();
        }

        public virtual async Task<TEntidade> ObterPrimeiroAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro, Func<IMongoQueryable<TEntidade>, IOrderedMongoQueryable<TEntidade>> ordenarPor) where TEntidade : class, IEntidade, new()
        {
            return await ObterQueryable<TEntidade>(filtro, ordenarPor).FirstOrDefaultAsync();
        }

        public virtual int ObterQuantidade<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : class, IEntidade, new()
        {
            return ObterQueryable<TEntidade>(filtro).Count();
        }

        public virtual Task<int> ObterQuantidadeAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : class, IEntidade, new()
        {
            return ObterQueryable<TEntidade>(filtro).CountAsync();
        }


        public virtual TEntidade Obter<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : class, IEntidade, new()
        {
            return ObterQueryable<TEntidade>(filtro, null).SingleOrDefault();
        }

        public virtual async Task<TEntidade> ObterAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : class, IEntidade, new()
        {
            return await ObterQueryable<TEntidade>(filtro, null).SingleOrDefaultAsync();
        }
        #endregion
    }
}
