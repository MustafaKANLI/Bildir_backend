﻿using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Communities.Queries.GetCommunityById
{
  public class GetCommunityByIdEventViewModel
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Tags { get; set; }
    public EventStates State { get; set; }
    public DateTime Date { get; set; }
  }
}