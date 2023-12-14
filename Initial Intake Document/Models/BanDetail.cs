using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class BanDetail
{
    public int BanId { get; set; }

    public int? PatronId { get; set; }

    public DateTime BanDate { get; set; }

    public DateTime? UnbanDate { get; set; }

    public string BanReason { get; set; } = null!;

    public virtual Patron? Patron { get; set; }
}
