using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class EmergencyContact
{
    public int EmergencyContactId { get; set; }

    public int? PatronId { get; set; }

    public int? UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Relationship { get; set; }

    public virtual ICollection<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();

    public virtual Patron? Patron { get; set; }

    public virtual User? User { get; set; }
}
