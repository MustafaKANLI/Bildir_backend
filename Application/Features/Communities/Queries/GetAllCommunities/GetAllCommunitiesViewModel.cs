﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Application.ViewModels.Student;

namespace Application.Features.Communities.Queries.GetAllCommunities
{
  public class GetAllCommunitiesViewModel
  {
    public string CreationKey { get; set; }
    public string ApplicationUserId { get; set; }
    public bool IsKeyUsed { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public ICollection<StudentViewModel> Followers { get; set; }
    //public Image AvatarImage { get; set; }
    //public Image BackgroundImage { get; set; }
    public string? InstagramLink { get; set; }
    public string? TwitterLink { get; set; }
    public string? FacebookLink { get; set; }
    public string? LinkedinLink { get; set; }
  }
}
