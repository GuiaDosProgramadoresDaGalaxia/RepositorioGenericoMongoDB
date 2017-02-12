using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GerenciadorMongo.Dominio.Interfaces
{

    public interface IRepositorio
    {
        /// <summary>
        /// Obtém uma lista de registros.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro da lista</param>
        /// <param name="ordenarPor">Ordenacao</param>
        /// <param name="skip">Pular</param>
        /// <param name="take">Pegar tantos</param>
        /// <returns></returns>
        IEnumerable<TEntidade> ObterTodos<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            Func<IMongoQueryable<TEntidade>, IOrderedMongoQueryable<TEntidade>> ordenarPor = null,
            int? skip = null,
            int? take = null)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Obtém uma lista de registros assincronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro da lista</param>
        /// <param name="ordenarPor">Ordenacao</param>
        /// <param name="skip">Pular</param>
        /// <param name="take">Pegar tantos</param>
        /// <returns></returns>
        Task<IEnumerable<TEntidade>> ObterTodosAsync<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            Func<IMongoQueryable<TEntidade>, IOrderedMongoQueryable<TEntidade>> ordenarPor = null,
            int? skip = null,
            int? take = null)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Obtém um registro.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro do registro</param>
        /// <returns></returns>
        TEntidade Obter<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Obtém um registro assicronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro do registro</param>
        /// <returns></returns>
        Task<TEntidade> ObterAsync<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Obtém o primeiro registro da busca.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro do registro</param>
        /// <param name="ordenarPor">Ordenacao do registro</param>
        /// <returns></returns>
        TEntidade ObterPrimeiro<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            Func<IMongoQueryable<TEntidade>, IOrderedMongoQueryable<TEntidade>> ordenarPor = null)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Obtém o primeiro registro da busca assincronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro do registro</param>
        /// <param name="ordenarPor">Ordenacao do registro</param>
        /// <returns></returns>
        Task<TEntidade> ObterPrimeiroAsync<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            Func<IMongoQueryable<TEntidade>, IOrderedMongoQueryable<TEntidade>> ordenarPor = null)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Obtém um registro atraves do seu Id.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="id">Id do registro</param>
        /// <returns></returns>
        TEntidade ObterPorId<TEntidade>(ObjectId id)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Obtém um registro atraves do seu Id assicronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="id">Id do registro</param>
        /// <returns></returns>
        Task<TEntidade> ObterPorIdAsync<TEntidade>(ObjectId id)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Obtém a quantidade de registros.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro da contagem</param>
        /// <returns></returns>
        int ObterQuantidade<TEntidade>(Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Obtém a quantidade de registros assicronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro da contagem</param>
        /// <returns></returns>
        Task<int> ObterQuantidadeAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Verifica se existe no registro. Retorna true ou false.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro da busca</param>
        /// <returns></returns>
        bool ObterExistente<TEntidade>(Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade, new();


        /// <summary>
        /// Verifica se existe no registro assicronamente. Retorna true ou false.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro da busca</param>
        /// <returns></returns>
        Task<bool> ObterExistenteAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Cria um registro.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="entidade">Entidade a ser adicionada</param>
        /// <param name="criadoPor">Quem criou a entidade</param>
        void Criar<TEntidade>(TEntidade entidade, string criadoPor = null)
        where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Cria um registro assincronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="entidade">Entidade a ser adicionada</param>
        /// <param name="criadoPor">Quem criou a entidade</param>
        Task CriarAsync<TEntidade>(TEntidade entidade, string criadoPor = null)
        where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Atualiza uma entidade do registro.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="entidade">Entidade a ser adicionada</param>
        /// <param name="modificadoPor">Quem modificou a entidade</param>
        void Atualizar<TEntidade>(TEntidade entidade, string modificadoPor = null)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Atualiza uma entidade do registro assincronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="entidade">Entidade a ser adicionada</param>
        /// <param name="modificadoPor">Quem modificou a entidade</param>
        Task AtualizarAsync<TEntidade>(TEntidade entidade, string modificadoPor = null)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Deleta um registro atravez da sua id.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="id">Id do registro</param>
        void Deletar<TEntidade>(ObjectId id)
            where TEntidade : class, IEntidade, new();

        /// <summary>
        /// Deleta um registro atravez da sua id assincronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="id">Id do registro</param>
        Task DeletarAsync<TEntidade>(ObjectId id)
            where TEntidade : class, IEntidade, new();
    }
}

