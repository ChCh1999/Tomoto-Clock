namespace TomatoClock
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("historylist.tomatolist")]
    public partial class TomatoList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TomatoList()
        {
            tcondition = new List<TCondition>();
        }

        [Column(TypeName = "uint")]
        public long wid { get; set; }

        [Key]
        [Column(TypeName = "uint")]
        public long tid { get; set; }

        [Column(TypeName = "uint")]
        public long tomatoTime { get; set; }

        [Column(TypeName = "uint")]
        public long signNum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<TCondition> tcondition { get; set; }

        public virtual WorkPlan workplan { get; set; }

        public TimeSpan TotalTime;

        public TomatoList(long t ,long s)
        {
            tcondition = new List<TCondition>();
            tomatoTime = t;
            TotalTime = new TimeSpan(0, 0, (int)t);
            signNum = s;
        }
    }
}
