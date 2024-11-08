using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace project.Models;

public partial class Projectprn212Context : DbContext
{
    public Projectprn212Context()
    {
    }

    public Projectprn212Context(DbContextOptions<Projectprn212Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Dom> Doms { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomAssignment> RoomAssignments { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=projectprn212; Trusted_Connection=SSPI;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5864CBE1CA4");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Account__roleId__3C69FB99");
        });

        modelBuilder.Entity<Dom>(entity =>
        {
            entity.HasKey(e => e.DomId).HasName("PK__Dom__B793E5376EB8CE52");

            entity.ToTable("Dom");

            entity.Property(e => e.DomId).HasColumnName("domId");
            entity.Property(e => e.ManageDom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__roles__CD98462A06C5EAD0");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Roomid).HasName("PK__Room__329925111667AE70");

            entity.ToTable("Room");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DomId).HasColumnName("domId");
            entity.Property(e => e.FloorRoom).HasColumnName("floorRoom");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Account).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Room__AccountID__4222D4EF");

            entity.HasOne(d => d.Dom).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.DomId)
                .HasConstraintName("FK__Room__domId__412EB0B6");
        });

        modelBuilder.Entity<RoomAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__RoomAssi__32499E57AF406628");

            entity.ToTable("RoomAssignment");

            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.DomId).HasColumnName("DomID");
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.RoomId).HasColumnName("RoomID");

            entity.HasOne(d => d.Account).WithMany(p => p.RoomAssignments)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__RoomAssig__Accou__5070F446");

            entity.HasOne(d => d.Dom).WithMany(p => p.RoomAssignments)
                .HasForeignKey(d => d.DomId)
                .HasConstraintName("FK__RoomAssig__DomID__4F7CD00D");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomAssignments)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__RoomAssig__RoomI__5165187F");

            entity.HasOne(d => d.Status).WithMany(p => p.RoomAssignments)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__RoomAssig__Statu__4E88ABD4");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__36257A1820A35B06");

            entity.ToTable("Status");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("statusId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
