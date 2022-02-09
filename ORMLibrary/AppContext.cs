using System.Data.Entity;

namespace ORMLibrary
{
    public partial class AppContext : DbContext
    {
        public AppContext()
            : base("name=DbContext")
        {
        }

        public virtual DbSet<Citizenship> Citizenships { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Disability> Disabilities { get; set; }
        public virtual DbSet<MartialStatus> MartialStatus { get; set; }
        public virtual DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citizenship>()
                .Property(e => e.Country)
                .IsUnicode(true);

            modelBuilder.Entity<Citizenship>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.Citizenship)
                .HasForeignKey(e => e.CitezenshipId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Surname)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.Patronymic)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.PassportSeries)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.PassportNumber)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.IssuedBy)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.IdentificationNumber)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.BirthPlace)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.ResidenceActualAddress)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.HomePhoneNumber)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.MobilePhoneNumber)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.ResidenceAddress)
                .IsUnicode(true);

            modelBuilder.Entity<Client>()
                .Property(e => e.MonthlyIncome)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Disability>()
                .Property(e => e.Status)
                .IsUnicode(true);

            modelBuilder.Entity<Disability>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.Disability)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MartialStatus>()
                .Property(e => e.Status)
                .IsUnicode(true);

            modelBuilder.Entity<MartialStatus>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.MartialStatus)
                .HasForeignKey(e => e.MaritalStatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Place>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<Place>()
                .Property(e => e.Country)
                .IsUnicode(true);

            modelBuilder.Entity<Place>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.Place)
                .HasForeignKey(e => e.ResidenceActualPlaceId)
                .WillCascadeOnDelete(false);
        }
    }
}
