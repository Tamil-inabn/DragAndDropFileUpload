using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DragAndDrop.EntityModels;

namespace DragAndDrop.DbContexts
{
    public partial class UploadFileContext : DbContext
    {
        public UploadFileContext()
        {
        }

        public UploadFileContext(DbContextOptions<UploadFileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachment> Attachments { get; set; } = null!;
        public virtual DbSet<Register> Registers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CIPL1309_DOTNET\\MSSQLSERVER19;Initial Catalog=UploadFile;User ID=sa;Password=Colan123;MultipleActiveResultSets=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK_s");

                entity.ToTable("Attachment");

                entity.Property(e => e.Document).IsUnicode(false);

                entity.Property(e => e.No).HasColumnName("NO");

                entity.Property(e => e.Photo).IsUnicode(false);

                entity.HasOne(d => d.NoNavigation)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.No)
                    .HasConstraintName("FK__Attachment__Id__4CA06362");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.ToTable("Register");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
