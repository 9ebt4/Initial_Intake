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

    public virtual DbSet<Bed> Beds { get; set; }

    public virtual DbSet<CaseWorker> CaseWorkers { get; set; }

    public virtual DbSet<ContactCategory> ContactCategories { get; set; }

    public virtual DbSet<ContactInfo> ContactInfos { get; set; }

    public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; }

    public virtual DbSet<IntakeScreening> IntakeScreenings { get; set; }

    public virtual DbSet<MedicalCondition> MedicalConditions { get; set; }

    public virtual DbSet<Patron> Patrons { get; set; }

    public virtual DbSet<ResourcesNeeded> ResourcesNeededs { get; set; }

    public virtual DbSet<RoleCategory> RoleCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(Secret.OptionBuilder);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
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
            entity.Property(e => e.UserId).HasColumnName("UserID");

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
                .HasConstraintName("FK__ContactIn__UserI__06CD04F7");
        });

        modelBuilder.Entity<EmergencyContact>(entity =>
        {
            entity.HasKey(e => e.EmergencyContactId).HasName("PK__Emergenc__E8A61DAEA283C797");

            entity.Property(e => e.EmergencyContactId).HasColumnName("EmergencyContactID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PatronId).HasColumnName("PatronID");
            entity.Property(e => e.Relationship).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Patron).WithMany(p => p.EmergencyContacts)
                .HasForeignKey(d => d.PatronId)
                .HasConstraintName("FK__Emergency__Patro__7A672E12");

            entity.HasOne(d => d.User).WithMany(p => p.EmergencyContacts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Emergency__UserI__7B5B524B");
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
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IntakeScreeningId).HasColumnName("IntakeScreeningID");
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.AssignedBed).WithMany(p => p.Patrons)
                .HasForeignKey(d => d.AssignedBedId)
                .HasConstraintName("FK__Patrons__Assigne__778AC167");

            entity.HasOne(d => d.CaseWorker).WithMany(p => p.Patrons)
                .HasForeignKey(d => d.CaseWorkerId)
                .HasConstraintName("FK__Patrons__CaseWor__75A278F5");

            entity.HasOne(d => d.IntakeScreening).WithMany(p => p.Patrons)
                .HasForeignKey(d => d.IntakeScreeningId)
                .HasConstraintName("FK__Patrons__IntakeS__76969D2E");
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

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC21CF171D");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Users)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Users__CategoryI__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
