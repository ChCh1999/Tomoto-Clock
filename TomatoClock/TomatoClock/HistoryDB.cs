namespace TomatoClock
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HistoryDB : DbContext
    {
        public HistoryDB()
            : base("name=HistoryDB")
        {
            Database.CreateIfNotExists();
        }

        public virtual DbSet<TomatoList> tomatolist { get; set; }
        public virtual DbSet<WorkPlan> workplan { get; set; }
        public virtual DbSet<TCondition> tcondition { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TomatoList>()
                .HasMany(e => e.tcondition)
                .WithRequired(e => e.tomatolist)
                .HasForeignKey(e => e.toid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkPlan>()
                .Property(e => e.workName)
                .IsUnicode(false);

            modelBuilder.Entity<WorkPlan>()
                .HasMany(e => e.tomatolist)
                .WithRequired(e => e.workplan)
                .HasForeignKey(e => e.wid)
                .WillCascadeOnDelete(false);
        }
    }
}
