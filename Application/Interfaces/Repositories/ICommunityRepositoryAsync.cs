using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces.Repositories
{
  public interface ICommunityRepositoryAsync : IGenericRepositoryAsync<Community>
  {
    public Task<Community> GetCommunityByCreationKeyAsync(string creationKey);
  }
}
