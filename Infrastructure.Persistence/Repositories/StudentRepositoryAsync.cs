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
using Application.ViewModels.Community;
using AutoMapper;
using Application.Features.Students.Queries.GetAllStudents;

namespace Infrastructure.Persistence.Repositories
{
  public class StudentRepositoryAsync : GenericRepositoryAsync<Student>, IStudentRepositoryAsync
  {
    private readonly DbSet<Student> _students;
    private readonly IMapper _mapper;
    public StudentRepositoryAsync(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
    {
      _students = dbContext.Set<Student>();
      _mapper = mapper;
    }

    public async Task<Student> GetStudentByApplicationUserIdAsync(string applicationUserId)
    {
      return await _students
        .SingleOrDefaultAsync(x => x.ApplicationUserId == applicationUserId);
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
      return await _students
        .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<GetAllStudentsViewModel> GetStudentByApplicationUserIdWithRelationsAsync(string applicationUserId)
    {
      return await _students
        .Where(x => x.ApplicationUserId == applicationUserId)
        .Select(x => new GetAllStudentsViewModel
        {
          FirstName = x.FirstName,
          LastName = x.LastName,
          SchoolEmail = x.SchoolEmail,
          Gender = x.Gender,
          Faculty = x.Faculty,
          Department = x.Department,
          ApplicationUserId = x.ApplicationUserId,
          FollowedCommunities = x.FollowedCommunities.Select(sc => _mapper.Map<CommunityViewModel>(sc.Community)).ToList()
        })
        .SingleOrDefaultAsync();
    }

    public async Task<IReadOnlyList<GetAllStudentsViewModel>> GetStudentsWithRelationsAsync(int pageNumber, int pageSize)
    {
      return await _students
          .Select(x => new GetAllStudentsViewModel
            {
              FirstName = x.FirstName,
              LastName = x.LastName,
              SchoolEmail = x.SchoolEmail,
              Gender = x.Gender,
              Faculty = x.Faculty,
              Department = x.Department,
              ApplicationUserId = x.ApplicationUserId,
              FollowedCommunities = x.FollowedCommunities.Select(sc => _mapper.Map<CommunityViewModel>(sc.Community)).ToList()
            })
          .Skip((pageNumber - 1) * pageSize)
          .Take(pageSize)
          .AsNoTracking()
          .ToListAsync();
    }
  }
}
