using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Communities.Queries.GetCommunityById
{
  public class GetCommunityByIdQuery : IRequest<Response<Community>>
  {
    public int Id { get; set; }
    public class GetCommunityByIdQueryHandler : IRequestHandler<GetCommunityByIdQuery, Response<Community>>
    {
      private readonly ICommunityRepositoryAsync _communityRepository;
      public GetCommunityByIdQueryHandler(ICommunityRepositoryAsync communityRepository)
      {
        _communityRepository = communityRepository;
      }
      public async Task<Response<Community>> Handle(GetCommunityByIdQuery query, CancellationToken cancellationToken)
      {
        var community = await _communityRepository.GetByIdAsync(query.Id);
        if (community == null) throw new ApiException($"Community Not Found.");
        return new Response<Community>(community);
      }
    }
  }
}
