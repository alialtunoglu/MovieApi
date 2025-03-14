using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;

public class CreateCastCommandHandler:IRequestHandler<CreateCastCommand>
{
    private readonly MovieContext _movieContext;
    
    public CreateCastCommandHandler(MovieContext movieContext)
    {
        _movieContext = movieContext;
    }

    public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
    {
        _movieContext.Add(new Cast
        {
            Biography = request.Biography,
            ImageUrl = request.ImageUrl,
            Name = request.Name,
            Overview = request.Overview,
            Surname = request.Surname,
            Title = request.Title
        });
        await _movieContext.SaveChangesAsync();
     }
}