using System;
using System.Collections.Generic;

namespace Initial_Intake_Document.Models;

public partial class Patron
{
    public int PatronId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public int? CaseWorkerId { get; set; }

    public int? IntakeScreeningId { get; set; }

    public int? AssignedBedId { get; set; }

    public DateTime? LastCheckIn { get; set; }

    public int? WorkPassId { get; set; }

    public int PersonId { get; set; }

    public virtual Bed? AssignedBed { get; set; }

    public virtual ICollection<BanDetail> BanDetails { get; set; } = new List<BanDetail>();

    public virtual CaseWorker? CaseWorker { get; set; }

    public virtual ICollection<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();

    public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();

    public virtual IntakeScreening? IntakeScreening { get; set; }

    public virtual ICollection<MedicalCondition> MedicalConditions { get; set; } = new List<MedicalCondition>();

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<ResourcesNeeded> ResourcesNeededs { get; set; } = new List<ResourcesNeeded>();

    public virtual WorkPass? WorkPass { get; set; }
}
