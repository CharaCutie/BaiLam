namespace HW16.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SessionsModel : DbContext
    {
        public SessionsModel()
            : base("name=SessionsModel")
        {
        }

        public virtual DbSet<DBSession> DBSessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
