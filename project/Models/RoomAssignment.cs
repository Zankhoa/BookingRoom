using System;
using System.Collections.Generic;

namespace project.Models;

public partial class RoomAssignment
{
    public int AssignmentId { get; set; }

    public int? AccountId { get; set; }

    public int? RoomId { get; set; }

    public int? DomId { get; set; }

    public string? Note { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? StatusId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Dom? Dom { get; set; }

    public virtual Room? Room { get; set; }

    public virtual Status? Status { get; set; }
}
