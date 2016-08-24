using Ddd.Specification.Interfaces;

namespace Ddd.Specification.Common
{
    /// <summary>
    /// Uma implementação específica para ser usada quando uma <see cref="ISpecification{TEntity}"/>
    /// é usada para filtro em alguma busca.
    /// </summary>
    /// <typeparam name="TEntity">O tipo de entidade a que a especificação se aplica.
    /// Não confundir com o tipo do filtro</typeparam>
    public abstract class FilterSpecificationBase<TEntity> : SpecificationBase<TEntity>
    {
        /// <summary>
        /// Define uma nova instância de um <see cref="FilterSpecificationBase{TEntity}"/>
        /// </summary>
        /// <param name="filtro">O filtro a ser aplicado na especificação</param>
        // ReSharper disable once UnusedParameter.Local
        protected FilterSpecificationBase(object filtro)
        {
        }
    }
}