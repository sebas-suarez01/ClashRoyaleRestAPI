using ClashRoyaleRestAPI.Application.Responses;

namespace ClashRoyaleRestAPI.Application.Interfaces
{
    public interface IPredifinedQueries
    {
        Task<IEnumerable<FirstQueryResponse>> FirstQuery();
    }
}
