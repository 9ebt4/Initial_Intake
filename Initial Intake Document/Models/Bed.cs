using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class Bed
{
    public int BedId { get; set; }

    public string BedName { get; set; } = null!;

    public bool? CheckedIn { get; set; }

    public virtual ICollection<Patron> Patrons { get; set; } = new List<Patron>();
}
