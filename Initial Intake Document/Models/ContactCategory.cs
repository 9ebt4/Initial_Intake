using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class ContactCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();
}
