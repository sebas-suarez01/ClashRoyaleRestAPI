using ClashRoyaleRestAPI.Application.Predefined_Queries.SecondQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.FirstQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.ThirdQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.FourthQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.FifthQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.SixthQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.SeventhQuery;

namespace ClashRoyaleRestAPI.Application.Interfaces;

public interface IPredefinedQueries
{
    Task<IEnumerable<FirstQueryResponse>> FirstQuery();
    Task<IEnumerable<SecondQueryResponse>> SecondQuery();
    Task<IEnumerable<ThirdQueryResponse>> ThirdQuery();
    Task<IEnumerable<FourthQueryResponse>> FourthQuery();
    Task<IEnumerable<FifthQueryResponse>> FifthQuery(int trophies);
    Task<IEnumerable<SixthQueryResponse>> SixthQuery();
    Task<IEnumerable<SeventhQueryResponse>> SeventhQuery(int year);
}
