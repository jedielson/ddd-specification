using System;
using System.Linq.Expressions;

namespace Ddd.Specification.Interfaces
{
    /// <summary>
    /// Define uma especificação de acordo com o modelo DDD
    /// <para>
    /// <i>Specification</i> é um poderoso e suscinto desgin pattern que pode ser usado
    /// para comparar um objeto à uma simples regra
    /// </para>
    /// <para>
    /// Ela também diminui o acoplamento e aumenta a capacidade de extensão de 
    /// comportamentos de objetos com base em alguns critérios
    /// </para>
    /// <para>
    /// Além disso, é uma poderosa ferramenta para especificação de filtros em 
    /// seleções nas cabadas de persistência de dados.
    /// </para>
    /// </summary>
    /// <typeparam name="TEntity">O tipo de dado a que se aplica a especificação</typeparam>
    /// <see cref="http://www.martinfowler.com/apsupp/spec.pdf">Artigo do Martin Fowler que descreve o pattern Specification</see>
    public interface ISpecification<TEntity>
    {
        /// <summary>
        /// Define uma árvore de expressão que aplica a regra ao objeto
        /// </summary>
        Expression<Func<TEntity, bool>> SpecExpression { get; }

        /// <summary>
        /// Valida se um determinado objeto satisfaz a especificação
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>um boolean. Se true, a especificação foi atendida.</returns>
        bool IsSatisfiedBy(TEntity entity);
    }
}