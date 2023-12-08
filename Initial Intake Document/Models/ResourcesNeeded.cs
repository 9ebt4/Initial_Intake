using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class ResourcesNeeded
{
    public int ResourcesNeededId { get; set; }

    public int? PatronId { get; set; }

    public string Category { get; set; } = null!;

    public string? Details { get; set; }

    public virtual Patron? Patron { get; set; }
}
