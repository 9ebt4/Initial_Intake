using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class EmergencyContact
{
    public int EmergencyContactId { get; set; }

    public int? PatronId { get; set; }

    public string? Relationship { get; set; }

    public int? PersonId { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();

    public virtual Patron? Patron { get; set; }

    public virtual Person? Person { get; set; }

    public virtual User? User { get; set; }
}
