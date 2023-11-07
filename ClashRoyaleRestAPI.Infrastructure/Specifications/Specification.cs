using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications
{
    public abstract class Specification<TModel>
        where TModel : class
    {
        protected Specification(Expression<Func<TModel, bool>> criteria)
        {
            Criteria = criteria;
        }
        public bool IsSplitQuery { get; protected set; }
        public Expression<Func<TModel, bool>> Criteria { get; }
        public List<Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>>> Includes { get; } = new();
        public Expression<Func<TModel, object>>? OrderBy { get; private set; }
        public Expression<Func<TModel, object>>? OrderByDescending { get; private set; }

        protected void AddInclude(Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> includeExpression) =>
            Includes.Add(includeExpression);

        protected void AddOrderBy(Expression<Func<TModel, object>> orderBy) =>
            OrderBy = orderBy;

        protected void AddOrderByDescending(Expression<Func<TModel, object>> orderByDescending) =>
            OrderByDescending = orderByDescending;


    }
}
