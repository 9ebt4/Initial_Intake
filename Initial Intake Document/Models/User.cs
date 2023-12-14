using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class User
{
    public int? CategoryId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public string GoogleId { get; set; } = null!;

    public int UserId { get; set; }

    public int? PersonId { get; set; }

    public virtual ICollection<Alteration> Alterations { get; set; } = new List<Alteration>();

    public virtual RoleCategory? Category { get; set; }

    public virtual ICollection<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();

    public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();

    public virtual Person? Person { get; set; }
}
