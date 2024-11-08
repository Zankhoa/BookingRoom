using System;
using System.Collections.Generic;

namespace project.Models;

public partial class Dom
{
    public int DomId { get; set; }

    public string Name { get; set; } = null!;

    public int TotalRooms { get; set; }

    public string? ManageDom { get; set; }

    public virtual ICollection<RoomAssignment> RoomAssignments { get; set; } = new List<RoomAssignment>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
