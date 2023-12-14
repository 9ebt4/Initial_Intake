using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Initial_Intake_Document.Models;

public partial class ShelterDbContext : DbContext
{
    public ShelterDbContext()
    {
    }

    public ShelterDbContext(DbContextOptions<ShelterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alteration> Alterations { get; set; }

    public virtual DbSet<AlterationType> AlterationTypes { get; set; }

    public virtual DbSet<BanDetail> BanDetails { get; set; }

    public virtual DbSet<Bed> Beds { get; set; }

    public virtual DbSet<CaseWorker> CaseWorkers { get; set; }

    public virtual DbSet<ContactCategory> ContactCategories { get; set; }

    public virtual DbSet<ContactInfo> ContactInfos { get; set; }

    public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; }

    public virtual DbSet<IntakeScreening> IntakeScreenings { get; set; }

    public virtual DbSet<MedicalCondition> MedicalConditions { get; set; }

    public virtual DbSet<Patron> Patrons { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<ResourcesNeeded> ResourcesNeededs { get; set; }

    public virtual DbSet<RoleCategory> RoleCategories { get; set; }

    public virtual DbSet<TrackedTable> TrackedTables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkPass> WorkPasses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ShelterDB;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alteration>(entity =>
        {
            entity.HasKey(e => e.AlterId).HasName("PK__Alterati__BDF6A977B7E273E6");

            entity.Property(e => e.AlterId).HasColumnName("AlterID");
            entity.Property(e => e.AlterTypeId).HasColumnName("AlterTypeID");
            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.AlterType).WithMany(p => p.Alterations)
                .HasForeignKey(d => d.AlterTypeId)
                .HasConstraintName("FK__Alteratio__Alter__45BE5BA9");

            entity.HasOne(d => d.Table).WithMany(p => p.Alterations)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK__Alteratio__Table__44CA3770");

            entity.HasOne(d => d.User).WithMany(p => p.Alterations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Alterations_Users");
        });

        modelBuilder.Entity<AlterationType>(entity =>
        {
            entity.HasKey(e => e.AlterTypeId).HasName("PK__Alterati__00E47D6611945662");

            entity.Property(e => e.AlterTypeId).HasColumnName("AlterTypeID");
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<BanDetail>(entity =>
        {
            entity.HasKey(e => e.BanId).HasName("PK__BanDetai__991CE765427C71D5");

            entity.Property(e => e.BanId).HasColumnName("BanID");
            entity.Property(e => e.PatronId).HasColumnName("PatronID");

            entity.HasOne(d => d.Patron).WithMany(p => p.BanDetails)
                .HasForeignKey(d => d.PatronId)
                .HasConstraintName("FK__BanDetail__Patro__3C34F16F");
        });

        modelBuilder.Entity<Bed>(entity =>
        {
            entity.HasKey(e => e.BedId).HasName("PK__Beds__A8A710604FEE64FD");

            entity.Property(e => e.BedId).HasColumnName("BedID");
            entity.Property(e => e.BedName).HasMaxLength(50);
        });

        modelBuilder.Entity<CaseWorker>(entity =>
        {
            entity.HasKey(e => e.CaseWorkerId).HasName("PK__CaseWork__CFB8410D411A8186");

            entity.Property(e => e.CaseWorkerId).HasColumnName("CaseWorkerID");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");

            entity.HasOne(d => d.Person).WithMany(p => p.CaseWorkers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CaseWorkers_Person");
        });

        modelBuilder.Entity<ContactCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__ContactC__19093A2BD8B8BD41");

            entity.ToTable("ContactCategory");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<ContactInfo>(entity =>
        {
            entity.HasKey(e => e.ContactInfoId).HasName("PK__ContactI__7B7333D96F8F3D36");

            entity.ToTable("ContactInfo");

            entity.Property(e => e.ContactInfoId).HasColumnName("ContactInfoID");
            entity.Property(e => e.CaseWorkerId).HasColumnName("CaseWorkerID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.EmergencyContactId).HasColumnName("EmergencyContactID");
            entity.Property(e => e.PatronId).HasColumnName("PatronID");

            entity.HasOne(d => d.CaseWorker).WithMany(p => p.ContactInfos)
                .HasForeignKey(d => d.CaseWorkerId)
                .HasConstraintName("FK__ContactIn__CaseW__05D8E0BE");

            entity.HasOne(d => d.Category).WithMany(p => p.ContactInfos)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__ContactIn__Categ__07C12930");

            entity.HasOne(d => d.EmergencyContact).WithMany(p => p.ContactInfos)
                .HasForeignKey(d => d.EmergencyContactId)
                .HasConstraintName("FK__ContactIn__Emerg__04E4BC85");

            entity.HasOne(d => d.Patron).WithMany(p => p.ContactInfos)
                .HasForeignKey(d => d.PatronId)
                .HasConstraintName("FK__ContactIn__Patro__03F0984C");

            entity.HasOne(d => d.User).WithMany(p => p.ContactInfos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ContactInfo_Users");
        });

        modelBuilder.Entity<EmergencyContact>(entity =>
        {
            entity.HasKey(e => e.EmergencyContactId).HasName("PK__Emergenc__E8A61DAEA283C797");

            entity.Property(e => e.EmergencyContactId).HasColumnName("EmergencyContactID");
            entity.Property(e => e.PatronId).HasColumnName("PatronID");
            entity.Property(e => e.Relationship).HasMaxLength(50);

            entity.HasOne(d => d.Patron).WithMany(p => p.EmergencyContacts)
                .HasForeignKey(d => d.PatronId)
                .HasConstraintName("FK__Emergency__Patro__7A672E12");

            entity.HasOne(d => d.Person).WithMany(p => p.EmergencyContacts)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_EmergencyContacts_Person");

            entity.HasOne(d => d.User).WithMany(p => p.EmergencyContacts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_EmergencyContacts_Users");
        });

        modelBuilder.Entity<IntakeScreening>(entity =>
        {
            entity.HasKey(e => e.IntakeScreeningId).HasName("PK__IntakeSc__921AC8521443D09B");

            entity.ToTable("IntakeScreening");

            entity.Property(e => e.IntakeScreeningId).HasColumnName("IntakeScreeningID");
            entity.Property(e => e.SoscreeningCompleted).HasColumnName("SOScreeningCompleted");
        });

        modelBuilder.Entity<MedicalCondition>(entity =>
        {
            entity.HasKey(e => e.MedicalConditionId).HasName("PK__MedicalC__5C8871586DD88C53");

            entity.Property(e => e.MedicalConditionId).HasColumnName("MedicalConditionID");
            entity.Property(e => e.ConditionName).HasMaxLength(100);
            entity.Property(e => e.PatronId).HasColumnName("PatronID");

            entity.HasOne(d => d.Patron).WithMany(p => p.MedicalConditions)
                .HasForeignKey(d => d.PatronId)
                .HasConstraintName("FK__MedicalCo__Patro__7E37BEF6");
        });

        modelBuilder.Entity<Patron>(entity =>
        {
            entity.HasKey(e => e.PatronId).HasName("PK__Patrons__14EC661A47B035A6");

            entity.Property(e => e.PatronId).HasColumnName("PatronID");
            entity.Property(e => e.AssignedBedId).HasColumnName("AssignedBedID");
            entity.Property(e => e.CaseWorkerId).HasColumnName("CaseWorkerID");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.IntakeScreeningId).HasColumnName("IntakeScreeningID");
            entity.Property(e => e.LastCheckIn)
                .HasColumnType("datetime")
                .HasColumnName("Last_Check_In");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.WorkPassId).HasColumnName("WorkPassID");

            entity.HasOne(d => d.AssignedBed).WithMany(p => p.Patrons)
                .HasForeignKey(d => d.AssignedBedId)
                .HasConstraintName("FK__Patrons__Assigne__778AC167");

            entity.HasOne(d => d.CaseWorker).WithMany(p => p.Patrons)
                .HasForeignKey(d => d.CaseWorkerId)
                .HasConstraintName("FK__Patrons__CaseWor__75A278F5");

            entity.HasOne(d => d.IntakeScreening).WithMany(p => p.Patrons)
                .HasForeignKey(d => d.IntakeScreeningId)
                .HasConstraintName("FK__Patrons__IntakeS__76969D2E");

            entity.HasOne(d => d.Person).WithMany(p => p.Patrons)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patrons_Person");

            entity.HasOne(d => d.WorkPass).WithMany(p => p.Patrons)
                .HasForeignKey(d => d.WorkPassId)
                .HasConstraintName("FK__Patrons__WorkPas__503BEA1C");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFB85209E8348");

            entity.ToTable("Person");

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<ResourcesNeeded>(entity =>
        {
            entity.HasKey(e => e.ResourcesNeededId).HasName("PK__Resource__6065056347393D75");

            entity.ToTable("ResourcesNeeded");

            entity.Property(e => e.ResourcesNeededId).HasColumnName("ResourcesNeededID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.PatronId).HasColumnName("PatronID");

            entity.HasOne(d => d.Patron).WithMany(p => p.ResourcesNeededs)
                .HasForeignKey(d => d.PatronId)
                .HasConstraintName("FK__Resources__Patro__01142BA1");
        });

        modelBuilder.Entity<RoleCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__RoleCate__19093A2B4888B439");

            entity.ToTable("RoleCategory");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<TrackedTable>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__TrackedT__7D5F018EB5FDA791");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.TableName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__A6FBF31AF417B01A");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GoogleId)
                .HasMaxLength(255)
                .HasColumnName("GoogleID");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PersonId).HasColumnName("PersonID");

            entity.HasOne(d => d.Category).WithMany(p => p.Users)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Users__CategoryI__5165187F");

            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_Users_Person");
        });

        modelBuilder.Entity<WorkPass>(entity =>
        {
            entity.HasKey(e => e.WorkPassId).HasName("PK__WorkPass__7BBD8D32770BDA50");

            entity.ToTable("WorkPass");

            entity.Property(e => e.WorkPassId).HasColumnName("WorkPassID");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.JobName).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
