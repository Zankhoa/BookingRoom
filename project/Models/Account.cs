using System;
using System.Collections.Generic;

namespace project.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public string? FullName { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<RoomAssignment> RoomAssignments { get; set; } = new List<RoomAssignment>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
