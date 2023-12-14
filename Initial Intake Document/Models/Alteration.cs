using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class Alteration
{
    public int AlterId { get; set; }

    public int? UserId { get; set; }

    public int? TableId { get; set; }

    public int? AlterTypeId { get; set; }

    public int? RecordId { get; set; }

    public DateTime AlterationDate { get; set; }

    public virtual AlterationType? AlterType { get; set; }

    public virtual TrackedTable? Table { get; set; }

    public virtual User? User { get; set; }
}
