namespace CodeFirstFromDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CFFD : DbContext
    {
        public CFFD()
            : base("name=CFFD")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.title)
                .IsUnicode(false);
        }
    }
}
