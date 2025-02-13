using AutoMapper;
using CineVerse.Domain;
using CineVerse.Persistence.DbContexts;
using FluentValidation;
using GN2.Business.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace CineVerse.Application.Contracts.User.ApplicationUser.Queries;

public class UserSingleQuery : IRequest<ReturnValues<CineUser>>
{
    [Required]
    public string Id { get; set; }
}

public class UserSingleQueryValidator : AbstractValidator<UserSingleQuery>
{
    public UserSingleQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty()
                             .NotNull()
                             .Must(x => !string.IsNullOrWhiteSpace(x))
                             .WithMessage("Id must not be empty or contain only whitespace.");

    }
}

public class UserSingleQueryHandler : IRequestHandler<UserSingleQuery, ReturnValues<CineUser>>
{
    private readonly IHttpContextAccessor _actionContextAccessor;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogger _logger;

    public UserSingleQueryHandler(
        IHttpContextAccessor actionContextAccessor,
        IMediator mediator,
        IMapper mapper,
        ApplicationDbContext context,
        ILogger logger
    )
    {
        this._actionContextAccessor = actionContextAccessor;
        this._mediator = mediator;
        this._mapper = mapper;
        this._context = context;
        this._logger = logger;
    }

    public async Task<ReturnValues<CineUser>> Handle(UserSingleQuery request, CancellationToken cancellationToken)
    {
        var result = new ReturnValues<CineUser>();

        return result;
    }
}