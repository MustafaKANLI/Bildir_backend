﻿using Application.Enums;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
  public static class DefaultCommunityUser
  {
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      //Seed Default User
      var defaultUser = new ApplicationUser
      {
        UserName = "communityuser",
        Email = "communityuser@gmail.com",
        FirstName = "Community User",
        EmailConfirmed = true,
        PhoneNumberConfirmed = true
      };
      if (userManager.Users.All(u => u.Id != defaultUser.Id))
      {
        var user = await userManager.FindByEmailAsync(defaultUser.Email);
        if (user == null)
        {
          await userManager.CreateAsync(defaultUser, "123Pa$$word!");
          await userManager.AddToRoleAsync(defaultUser, Roles.Community.ToString());
        }

      }
    }
  }
}