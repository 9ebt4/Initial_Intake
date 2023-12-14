using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class WorkPass
{
    public int WorkPassId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? JobName { get; set; }

    public string? Detail { get; set; }

    public virtual ICollection<Patron> Patrons { get; set; } = new List<Patron>();
}
