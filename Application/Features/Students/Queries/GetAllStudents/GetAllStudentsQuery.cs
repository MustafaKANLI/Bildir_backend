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

namespace Application.Features.Students.Queries.GetAllStudents
{
  public class GetAllStudentsQuery : IRequest<PagedResponse<IEnumerable<GetAllStudentsViewModel>>>
  {
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
  }
  public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, PagedResponse<IEnumerable<GetAllStudentsViewModel>>>
  {
    private readonly IStudentRepositoryAsync _studentRepository;
    private readonly IMapper _mapper;
    public GetAllStudentsQueryHandler(IStudentRepositoryAsync studentRepository, IMapper mapper)
    {
      _studentRepository = studentRepository;
      _mapper = mapper;
    }

    public async Task<PagedResponse<IEnumerable<GetAllStudentsViewModel>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
      var validFilter = _mapper.Map<GetAllStudentsParameter>(request);
      var student = await _studentRepository.GetStudentsWithRelationsAsync(validFilter.PageNumber, validFilter.PageSize);
      var studentViewModel = _mapper.Map<IEnumerable<GetAllStudentsViewModel>>(student);
      return new PagedResponse<IEnumerable<GetAllStudentsViewModel>>(studentViewModel, validFilter.PageNumber, validFilter.PageSize);
    }
  }
}
