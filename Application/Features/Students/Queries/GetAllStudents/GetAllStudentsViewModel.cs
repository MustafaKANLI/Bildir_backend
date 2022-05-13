using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Application.ViewModels.Community;

namespace Application.Features.Students.Queries.GetAllStudents
{
  public class GetAllStudentsViewModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ApplicationUserId { get; set; }
    public string SchoolEmail { get; set; }
    public ICollection<CommunityViewModel> FollowedCommunities { get; set; }
    public string Faculty { get; set; }
    public string Department { get; set; }
    public string Gender { get; set; }
  }
}
