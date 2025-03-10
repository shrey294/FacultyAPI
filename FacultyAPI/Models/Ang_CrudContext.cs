using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FacultyAPI.Models
{
    public partial class Ang_CrudContext : DbContext
    {
        public Ang_CrudContext()
        {
        }

        public Ang_CrudContext(DbContextOptions<Ang_CrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-L48UG33\\SQLEXPRESS;Database=Ang_Crud;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(e => e.FcId);

                entity.ToTable("Faculty");

                entity.Property(e => e.FcId).HasColumnName("Fc_id");

                entity.Property(e => e.FcAreaspecialization)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fc_Areaspecialization");

                entity.Property(e => e.FcDepartmentId).HasColumnName("Fc_departmentId");

                entity.Property(e => e.FcDesignation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fc_Designation");

                entity.Property(e => e.FcEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fc_Email");

                entity.Property(e => e.FcExYear).HasColumnName("Fc_ExYear");

                entity.Property(e => e.FcHighestEducation)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Fc_HighestEducation");

                entity.Property(e => e.FcImage)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Fc_Image");

                entity.Property(e => e.FcMobile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fc_mobile");

                entity.Property(e => e.FcName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fc_Name");

                entity.Property(e => e.FcProfile)
                    .IsUnicode(false)
                    .HasColumnName("Fc_profile");

                entity.Property(e => e.FcSeating)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fc_seating");

                entity.Property(e => e.FcSequence)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fc_sequence");

                entity.Property(e => e.FcSubjecttaught)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fc_subjecttaught");

                entity.Property(e => e.WorkingSince)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
