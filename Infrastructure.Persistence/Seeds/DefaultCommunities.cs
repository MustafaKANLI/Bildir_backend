using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities;
namespace Infrastructure.Persistence.Seeds
{
  public class DefaultCommunities
  {
    public static async Task<bool> SeedAsync(ICommunityRepositoryAsync communityRepository)
    {

      var community1 = new Community
      {
        Name = "Community 1",
        ApplicationUserId = "214c-124c4-c124f-421c-124c-124rf",
        CreationKey = "e5a88210-ebcc-44ad-a3aa-1e8f3b458508",
        IsKeyUsed = true,
        Email = "testcommunity@comun.com",
        Description = "This community is awesome",
        InstagramLink = null,
        TwitterLink = null,
        FacebookLink = null,
        LinkedinLink = null,
      };

      var communityList = await communityRepository.GetAllAsync();
      var _product1 = communityList.Where(c => c.Name.StartsWith(community1.Name)).Count();

      if (_product1 > 0) // ALREADY SEEDED
        return true;


      if (_product1 == 0)
        try
        {
          await communityRepository.AddAsync(community1);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          throw;
        }

      return false; // NOT ALREADY SEEDED

    }
  }
}
