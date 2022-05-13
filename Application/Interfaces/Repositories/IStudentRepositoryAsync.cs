using Application.Features.Students.Queries.GetAllStudents;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
  public interface IStudentRepositoryAsync : IGenericRepositoryAsync<Student>
  {
    public Task<Student> GetStudentByApplicationUserIdAsync(string applicationUserId);
    public Task<IReadOnlyList<GetAllStudentsViewModel>> GetStudentsWithRelationsAsync(int pageNumber, int pageSize);
    public Task<Student> GetStudentByIdAsync(int id);
    public Task<GetAllStudentsViewModel> GetStudentByApplicationUserIdWithRelationsAsync(string applicationUserId);
  }
}
