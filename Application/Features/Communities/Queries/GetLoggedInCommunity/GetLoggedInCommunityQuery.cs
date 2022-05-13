using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Communities.Queries.GetCommunityByApplicationUserId
{
  public class GetLoggedInCommunityQuery : IRequest<Response<Community>>
  {
    public class GetLoggedInCommunityQueryHandler : IRequestHandler<GetLoggedInCommunityQuery, Response<Community>>
    {
      private readonly ICommunityRepositoryAsync _communityRepository;
      private readonly IAuthenticatedUserService _authenticatedUserService;

      public GetLoggedInCommunityQueryHandler(ICommunityRepositoryAsync communityRepository, IAuthenticatedUserService authenticatedUserService)
      {
        _communityRepository = communityRepository;
        _authenticatedUserService = authenticatedUserService;
      }
      public async Task<Response<Community>> Handle(GetLoggedInCommunityQuery query, CancellationToken cancellationToken)
      {
        if(_authenticatedUserService.UserId == null) throw new ApiException($"User not logged in.");

        var community = await _communityRepository.GetCommunityByApplicationUserIdAsync(_authenticatedUserService.UserId);
        if (community == null) throw new ApiException($"Community Not Found.");
        return new Response<Community>(community);
      }
    }
  }
}
