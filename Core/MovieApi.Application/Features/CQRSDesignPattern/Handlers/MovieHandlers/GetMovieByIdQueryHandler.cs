using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;
        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<GetMovieQueryResult> Handle(GetMovieByIdQuery query){
            var value = await _context.Movies.FindAsync(query.MovieId);
            return new GetMovieQueryResult
            {
                MovieId = value.MovieId,
                CoverImageUrl = value.CoverImageUrl,
                CreatedYear = value.CreatedYear,
                Title = value.Title,
                Duration = value.Duration,
                Rating = value.Rating,
                ReleaseDate = value.ReleaseDate,
                Status = value.Status
            };
        }
    }
}