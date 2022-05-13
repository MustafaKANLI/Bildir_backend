using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using Application.ViewModels.Student;
using Application.Features.Communities.Queries.GetAllCommunities;

namespace Infrastructure.Persistence.Repositories
{
  public class CommunityRepositoryAsync : GenericRepositoryAsync<Community>, ICommunityRepositoryAsync
  {
    private readonly DbSet<Community> _communities;
    private readonly IMapper _mapper;
    public CommunityRepositoryAsync(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
    {
      _communities = dbContext.Set<Community>();
      _mapper = mapper;
    }

    public async Task<Community> GetCommunityByCreationKeyAsync(string creationKey)
    {
      return await _communities
        .SingleOrDefaultAsync(x => x.CreationKey == creationKey);
    }

    public async Task<Community> GetCommunityByApplicationUserIdAsync(string applicationUserId)
    {
      return await _communities
        .SingleOrDefaultAsync(x => x.ApplicationUserId == applicationUserId);
    }

    public async Task<IReadOnlyList<GetAllCommunitiesViewModel>> GetCommunitiesWithRelationsAsync(int pageNumber, int pageSize)
    {
      return await _communities
          .Select(c => new GetAllCommunitiesViewModel 
            {
              Name = c.Name,
              ApplicationUserId = c.ApplicationUserId,
              CreationKey = c.CreationKey,
              Description = c.Description,
              Email = c.Email,
              FacebookLink = c.FacebookLink,
              LinkedinLink = c.LinkedinLink,
              InstagramLink = c.InstagramLink,
              TwitterLink = c.TwitterLink,
              Followers = c.Followers.Select(sc => _mapper.Map<StudentViewModel>(sc.Student)).ToList(),
            })
          .Skip((pageNumber - 1) * pageSize)
          .Take(pageSize)
          .AsNoTracking()
          .ToListAsync();
    }

    public async Task<GetAllCommunitiesViewModel> GetCommunityByIdWithRelationsAsync(int id)
    {
      return await _communities
        .Where(c => c.Id == id)
        .Select(c => new GetAllCommunitiesViewModel
        {
          Name = c.Name,
          ApplicationUserId = c.ApplicationUserId,
          CreationKey = c.CreationKey,
          Description = c.Description,
          Email = c.Email,
          FacebookLink = c.FacebookLink,
          LinkedinLink = c.LinkedinLink,
          InstagramLink = c.InstagramLink,
          TwitterLink = c.TwitterLink,
          Followers = c.Followers.Select(sc => _mapper.Map<StudentViewModel>(sc.Student)).ToList(),
        })
        .SingleOrDefaultAsync();
    }

    public async Task<Community> GetCommunityByIdAsync(int id)
    {
      return await _communities
        .SingleOrDefaultAsync(x => x.Id == id);
    }
  }
}
