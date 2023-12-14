using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class AlterationType
{
    public int AlterTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Alteration> Alterations { get; set; } = new List<Alteration>();
}
