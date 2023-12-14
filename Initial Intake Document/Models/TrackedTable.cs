using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class TrackedTable
{
    public int TableId { get; set; }

    public string TableName { get; set; } = null!;

    public virtual ICollection<Alteration> Alterations { get; set; } = new List<Alteration>();
}
