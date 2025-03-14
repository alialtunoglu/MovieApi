using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;

public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastByIdQueryResult>>
{
    private readonly MovieContext _context;

    public GetCastQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetCastByIdQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Casts.ToListAsync();
        return values.Select(x => new GetCastByIdQueryResult
        {
            CastId = x.CastId,
            Biography = x.Biography,
            ImageUrl = x.ImageUrl,
            Name = x.Name,
            Overview = x.Overview,
            Surname = x.Surname,
            Title = x.Title
        }).ToList();
    }
}