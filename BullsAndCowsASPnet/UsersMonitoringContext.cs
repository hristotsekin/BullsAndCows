namespace BullsAndCowsASPnet
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using BullsAndCowsASPnet.Entities;

    public partial class UsersMonitoringContext : DbContext
    {
        private DbSet<User> users { get; set; }
        public UsersMonitoringContext()
            : base()
        {
            Database.SetInitializer<UsersMonitoringContext>(new CreateDatabaseIfNotExists<UsersMonitoringContext>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
