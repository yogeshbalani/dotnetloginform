namespace PatientManagement.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PatientContext : DbContext
    {
        public PatientContext()
            : base("name=PatientContext")
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.ContactNumber)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
