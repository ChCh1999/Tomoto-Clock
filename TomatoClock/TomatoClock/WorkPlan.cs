namespace TomatoClock
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("historylist.workplan")]
    public partial class WorkPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkPlan()
        {
            tomatolist = new List<TomatoList>();
        }

        [Key]
        [Column(TypeName = "uint")]
        public long wpid { get; set; }

        [Required]
        [StringLength(20)]
        public string workName { get; set; }

        [Column(TypeName = "uint")]
        public long NumofDay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<TomatoList> tomatolist { get; set; }

        public WorkPlan(string wname, long num)
        {
            tomatolist = new List<TomatoList>();
            workName = wname;
            NumofDay = num;
        }
    }
}
