using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<TModel> GetQuery<TModel>(
            IQueryable<TModel> inputQueryable,
            Specification<TModel> specification)
            where TModel : class
        {
            IQueryable<TModel> queryable = inputQueryable;

            if (specification.Criteria is not null)
            {
                queryable = queryable.Where(specification.Criteria);
            }

            queryable = specification.Includes.Aggregate(
                queryable, (current, include) => include(current));

            if (specification.OrderBy is not null)
            {
                queryable = queryable.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending is not null)
            {
                queryable = queryable.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.IsSplitQuery)
            {
                queryable = queryable.AsSplitQuery();
            }

            return queryable;
        }
    }
}
