namespace Neonatal_App.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Neonatal_App_DB : DbContext
    {
        public Neonatal_App_DB()
            : base("name=Neonatal_App_DB")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.AspNetUsers_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.ethnicity)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.street_name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.zip_code)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.county)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Surveys)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.client_id)
                .WillCascadeOnDelete(false);
        }
    }
}
