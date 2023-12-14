using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class ContactInfo
{
    public int ContactInfoId { get; set; }

    public int? PatronId { get; set; }

    public int? EmergencyContactId { get; set; }

    public int? CaseWorkerId { get; set; }

    public int? CategoryId { get; set; }

    public string? Details { get; set; }

    public int? UserId { get; set; }

    public virtual CaseWorker? CaseWorker { get; set; }

    public virtual ContactCategory? Category { get; set; }

    public virtual EmergencyContact? EmergencyContact { get; set; }

    public virtual Patron? Patron { get; set; }

    public virtual User? User { get; set; }
}
