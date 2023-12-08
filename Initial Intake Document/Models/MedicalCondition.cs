using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class MedicalCondition
{
    public int MedicalConditionId { get; set; }

    public int? PatronId { get; set; }

    public string ConditionName { get; set; } = null!;

    public string? Details { get; set; }

    public virtual Patron? Patron { get; set; }
}
