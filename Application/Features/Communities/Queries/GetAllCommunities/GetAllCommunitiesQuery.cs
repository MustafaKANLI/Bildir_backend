using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Communities.Queries.GetAllCommunities
{
  public class GetAllCommunitiesQuery : IRequest<PagedResponse<IEnumerable<GetAllCommunitiesViewModel>>>
  {
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
  }
  public class GetAllCommunitiesQueryHandler : IRequestHandler<GetAllCommunitiesQuery, PagedResponse<IEnumerable<GetAllCommunitiesViewModel>>>
  {
    private readonly ICommunityRepositoryAsync _communityRepository;
    private readonly IMapper _mapper;
    public GetAllCommunitiesQueryHandler(ICommunityRepositoryAsync communityRepository, IMapper mapper)
    {
      _communityRepository = communityRepository;
      _mapper = mapper;
    }

    public async Task<PagedResponse<IEnumerable<GetAllCommunitiesViewModel>>> Handle(GetAllCommunitiesQuery request, CancellationToken cancellationToken)
    {
      var validFilter = _mapper.Map<GetAllCommunitiesParameter>(request);
      var community = await _communityRepository.GetAllAsync();
      var communityViewModel = _mapper.Map<IEnumerable<GetAllCommunitiesViewModel>>(community);
      return new PagedResponse<IEnumerable<GetAllCommunitiesViewModel>>(communityViewModel, validFilter.PageNumber, validFilter.PageSize);
    }
  }
}
