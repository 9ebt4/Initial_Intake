using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class Patron
{
    public int PatronId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int? CaseWorkerId { get; set; }

    public int? IntakeScreeningId { get; set; }

    public int? AssignedBedId { get; set; }

    public bool? HasWorkPass { get; set; }

    public virtual Bed? AssignedBed { get; set; }

    public virtual CaseWorker? CaseWorker { get; set; }

    public virtual ICollection<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();

    public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();

    public virtual IntakeScreening? IntakeScreening { get; set; }

    public virtual ICollection<MedicalCondition> MedicalConditions { get; set; } = new List<MedicalCondition>();

    public virtual ICollection<ResourcesNeeded> ResourcesNeededs { get; set; } = new List<ResourcesNeeded>();
}
