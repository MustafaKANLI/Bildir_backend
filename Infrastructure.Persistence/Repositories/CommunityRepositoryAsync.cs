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

namespace Infrastructure.Persistence.Repositories
{
  public class CommunityRepositoryAsync : GenericRepositoryAsync<Community>, ICommunityRepositoryAsync
  {
    private readonly DbSet<Community> _communities;
    public CommunityRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
      _communities = dbContext.Set<Community>();
    }

    public async Task<Community> GetCommunityByCreationKeyAsync(string creationKey)
    {
      return await _communities
        .SingleOrDefaultAsync(x => x.CreationKey == creationKey);
    }
  }
}
