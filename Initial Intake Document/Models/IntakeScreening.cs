using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class IntakeScreening
{
    public int IntakeScreeningId { get; set; }

    public bool? InitialScreeningCompleted { get; set; }

    public bool? RequirementsAgreement { get; set; }

    public bool? TenRulesAgreement { get; set; }

    public bool? SoscreeningCompleted { get; set; }

    public virtual ICollection<Patron> Patrons { get; set; } = new List<Patron>();
}
