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

        [Key]
        public short tid { get; set; }

        public short wid { get; set; }

        public int tomatoTime { get; set; }

        public short signNum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<TCondition> tcondition { get; set; }

        public virtual WorkPlan workplan { get; set; }

        public TomatoList(int totime, short snum, List<TCondition> list)
        {
            tomatoTime = totime;
            signNum = snum;
            tcondition = list;
        }
    }
}
