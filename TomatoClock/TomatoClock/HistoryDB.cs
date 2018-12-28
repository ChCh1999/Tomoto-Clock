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

        public virtual DbSet<TCondition> tcondition { get; set; }
        public virtual DbSet<TomatoList> tomatolist { get; set; }
        public virtual DbSet<WorkPlan> workplan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TomatoList>()
                .HasMany(e => e.tcondition)
                .WithOptional(e => e.tomatolist)
                .HasForeignKey(e => e.toid);

            modelBuilder.Entity<WorkPlan>()
                .Property(e => e.workName)
                .IsUnicode(false);

            modelBuilder.Entity<WorkPlan>()
                .Property(e => e.startTime)
                .IsUnicode(false);

            modelBuilder.Entity<WorkPlan>()
                .HasMany(e => e.tomatolist)
                .WithRequired(e => e.workplan)
                .HasForeignKey(e => e.wid)
                .WillCascadeOnDelete(false);
        }
    }
}
