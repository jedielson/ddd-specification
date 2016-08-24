using Ddd.Specification.Common;
using Ddd.Specification.Interfaces;

namespace Ddd.Specification.Extensions
{
    public static class SpecificationExtensionMethods
    {
        /// <summary>
        /// Efetua uma união entre duas especificações
        /// </summary>
        /// <typeparam name="TEntity">O tipo de dado da especificação resultante</typeparam>
        /// <param name="spec1">A primeira especificação</param>
        /// <param name="spec2">A segunda especificação</param>
        /// <returns>Um <see cref="ISpecification{TEntity}"/></returns>
        public static ISpecification<TEntity> And<TEntity>(this ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            return new AndSpecification<TEntity>(spec1, spec2);
        }

        /// <summary>
        /// Efetua intersecção entre duas especificações
        /// </summary>
        /// <typeparam name="TEntity">O tipo de dado da especificação resultante</typeparam>
        /// <param name="spec1">A primeira especificação</param>
        /// <param name="spec2">A segunda especificação</param>
        /// <returns>Um <see cref="ISpecification{TEntity}"/></returns>
        public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            return new OrSpecification<TEntity>(spec1, spec2);
        }

        /// <summary>
        /// Implementa a negação de uma especificação
        /// </summary>
        /// <typeparam name="TEntity">O tipo da especificação resultante</typeparam>
        /// <param name="spec">A especificação a ser negada</param>
        /// <returns>Um <see cref="ISpecification{TEntity}"/></returns>
        public static ISpecification<TEntity> Not<TEntity>(this ISpecification<TEntity> spec)
        {
            return new NotSpecification<TEntity>(spec);
        }
    }
}
