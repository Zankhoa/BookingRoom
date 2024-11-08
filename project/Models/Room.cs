using System;
using System.Collections.Generic;

namespace project.Models;

public partial class Room
{
    public int Roomid { get; set; }

    public string Name { get; set; } = null!;

    public int? Capacity { get; set; }

    public int? FloorRoom { get; set; }

    public string? Description { get; set; }

    public int? DomId { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Dom? Dom { get; set; }

    public virtual ICollection<RoomAssignment> RoomAssignments { get; set; } = new List<RoomAssignment>();
}
