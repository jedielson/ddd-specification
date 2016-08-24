using System;
using System.Linq.Expressions;
using Ddd.Specification.Interfaces;

namespace Ddd.Specification.Common
{
    internal class AndSpecification<TEntity> : SpecificationBase<TEntity>
    {
        protected ISpecification<TEntity> Spec1 { get; }

        protected ISpecification<TEntity> Spec2 { get; }

        internal AndSpecification(ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            if (spec1 == null)
                // ReSharper disable once LocalizableElement
                throw new ArgumentNullException(nameof(spec1), "O primeiro argumento da especificação não pode ser nulo.");

            if (spec2 == null)
                // ReSharper disable once LocalizableElement
                throw new ArgumentNullException(nameof(spec2), "O segundo argumento da especificação não pode ser nulo.");

            Spec1 = spec1;
            Spec2 = spec2;
        }

        public override Expression<Func<TEntity, bool>> SpecExpression
        {
            get
            {
                var param = Expression.Parameter(typeof(TEntity));
                var newExpression = Expression.Lambda<Func<TEntity, bool>>(
                    Expression.AndAlso(
                        Expression.Invoke(Spec1.SpecExpression, param),
                        Expression.Invoke(Spec2.SpecExpression, param)
                        ),
                    param);

                return newExpression;
            }
        }
    }
}
