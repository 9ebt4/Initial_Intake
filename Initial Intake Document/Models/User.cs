using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual RoleCategory? Category { get; set; }

    public virtual ICollection<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();

    public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();
}
