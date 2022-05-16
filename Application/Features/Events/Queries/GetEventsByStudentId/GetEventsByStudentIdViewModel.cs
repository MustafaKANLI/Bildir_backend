﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Events.Queries.GetEventsByStudentId
{
  public class GetEventsByStudentIdViewModel
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Tags { get; set; }
    public GetEventsByStudentIdCommunityViewModel EventOf { get; set; }
    public string State { get; set; }
    public DateTime Date { get; set; }
  }
}