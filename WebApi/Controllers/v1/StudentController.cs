using Application.Features.Communities.Commands.CreateCommunity;
//using Application.Features.Communities.Commands.DeleteAnnouncementById;
//using Application.Features.Communities.Commands.UpdateAnnouncement;
using Application.Features.Students.Queries.GetAllStudents;
using Application.Features.Students.Commands.AddFollowedCommunity;
using Application.Features.Students.Queries.GetStudentById;
using Application.Features.Students.Queries.GetLoggedInStudent;
using Application.Features.Students.Commands.UpdateStudent;
using Application.Features.Students.Commands.RegisterStudentToEvent;
using Microsoft.AspNetCore.Authorization;

//using Application.Features.Communities.Queries.GetAnnouncementById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Features.Students.Commands.AbandonEvent;
using Application.Features.Students.Commands.RemoveFollowedCommunity;

namespace WebApi.Controllers.v1
{
  [ApiVersion("1.0")]
  public class StudentController : BaseApiController
  {
    // GET: api/<controller>
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllStudentsParameter filter)
    {
      return Ok(await Mediator.Send(new GetAllStudentsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // POST api/<controller>/AddFollowedCommunity
    [HttpPost("AddFollowedCommunity")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> AddFollowedCommunity(AddFollowedCommunityCommand command)
    {
      return Ok(await Mediator.Send(command));
    }
    
    // POST api/<controller>/RegisterToEvent
    [HttpPost("RegisterToEvent")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> RegisterToEvent(RegisterStudentToEventCommand command)
    {
      return Ok(await Mediator.Send(command));
    }

    // POST api/<controller>/AbandonEvent
    [HttpPost("AbandonEvent")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> AbandonEvent(AbandonEventCommand command)
    {
      return Ok(await Mediator.Send(command));
    }

    // POST api/<controller>/RemoveFollowedCommunity
    [HttpPost("RemoveFollowedCommunity")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> RemoveFollowedCommunity(RemoveFollowedCommunityCommand command)
    {
      return Ok(await Mediator.Send(command));
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      return Ok(await Mediator.Send(new GetStudentByIdQuery { Id = id }));
    }

    // GET api/<controller>
    [HttpGet("CurrentlyLoggedIn")]
    public async Task<IActionResult> Get()
    {
      return Ok(await Mediator.Send(new GetLoggedInStudentQuery { }));
    }

    // POST api/<controller>
    //[HttpPost]
    ////        [Authorize]
    //public async Task<IActionResult> Post(CreateCommunityCommand command)
    //{
    //  return Ok(await Mediator.Send(command));
    //}

    // POST api/<controller>
    //[HttpPost("AddSocialMediaLinkToCommunity")]
    ////        [Authorize]
    //public async Task<IActionResult> AddSocialMediaLinkToCommunity(AddSocialMediaLinkToPersonnelCommand command)
    //{
    //  return Ok(await Mediator.Send(command));
    //}


    // PUT api/<controller>/5
    [HttpPut("{applicationUserId}")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> Put(string applicationUserId, UpdateStudentCommand command)
    {
      if (applicationUserId != command.ApplicationUserId)
      {
        return BadRequest();
      }
      return Ok(await Mediator.Send(command));
    }

    // DELETE api/<controller>/5
    //[HttpDelete("{id}")]
    ////       [Authorize]
    //public async Task<IActionResult> Delete(int id)
    //{
    //  return Ok(await Mediator.Send(new DeletePersonnelByIdCommand { Id = id }));
    //}
  }
}
