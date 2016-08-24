using System;
using System.Linq.Expressions;
using Ddd.Specification.Interfaces;

namespace Ddd.Specification.Common
{
    /// <summary>
    /// Define um conjunto de operações básicas para o pattern <see cref="ISpecification{TEntity}"/>
    /// </summary>
    /// <typeparam name="TEntity">O tipo a que se refere à especificação</typeparam>
    public abstract class SpecificationBase<TEntity> : ISpecification<TEntity>
    {
        private Func<TEntity, bool> _compiledExpression;

        /// <summary>
        /// Uma <see cref="Func{TEntity, TResult}"/> que define a especificação
        /// </summary>
        public Func<TEntity, bool> CompiledExpression => _compiledExpression ?? (_compiledExpression = SpecExpression.Compile());

        /// <summary>
        /// Define uma árvore de expressão que aplica a regra ao objeto
        /// </summary>
        public abstract Expression<Func<TEntity, bool>> SpecExpression { get; }

        /// <summary>
        /// Valida se um determinado objeto satisfaz a especificação
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>um boolean. Se true, a especificação foi atendida.</returns>
        public bool IsSatisfiedBy(TEntity entity)
        {
            return CompiledExpression(entity);
        }
    }
}
