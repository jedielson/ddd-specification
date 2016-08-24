using System;
using System.Linq.Expressions;
using Ddd.Specification.Interfaces;

namespace Ddd.Specification.Common
{
    internal class NotSpecification<TEntity> : SpecificationBase<TEntity>
    {
        protected ISpecification<TEntity> Wrapped { get; }

        internal NotSpecification(ISpecification<TEntity> spec)
        {
            if (spec == null)
            {
                // ReSharper disable once LocalizableElement
                throw new ArgumentNullException(nameof(spec), "O argumento da especificação não pode ser nulo.");
            }

            Wrapped = spec;
        }

        public override Expression<Func<TEntity, bool>> SpecExpression
        {
            get
            {
                var param = Expression.Parameter(typeof(TEntity));

                var newExpression = Expression.Lambda<Func<TEntity, bool>>(
                    Expression.Not(
                        Expression.Invoke(Wrapped.SpecExpression, param)
                    ),
                    param
                );

                return newExpression;
            }
        }
    }
}
