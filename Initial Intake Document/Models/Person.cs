using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<CaseWorker> CaseWorkers { get; set; } = new List<CaseWorker>();

    public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();

    public virtual ICollection<Patron> Patrons { get; set; } = new List<Patron>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
