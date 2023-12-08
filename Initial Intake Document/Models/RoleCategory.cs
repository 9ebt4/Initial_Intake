using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class RoleCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
