using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class CaseWorker
{
    public int CaseWorkerId { get; set; }

    public int PersonId { get; set; }

    public virtual ICollection<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();

    public virtual ICollection<Patron> Patrons { get; set; } = new List<Patron>();

    public virtual Person Person { get; set; } = null!;
}
