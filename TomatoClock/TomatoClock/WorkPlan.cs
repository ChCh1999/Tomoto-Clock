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
            this.StartDay = DateTime.Now.Date.ToString("yyyyMMdd");
            tomatolist = new List<TomatoList>();
        }
        public WorkPlan(String WPName,int day)
        {
            this.workName = WPName;
            this.NumofDay = day;
            this.StartDay = DateTime.Now.Date.ToString("yyyyMMdd");
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

        [Column(TypeName ="varchar")]
        [StringLength(8)]
        public String StartDay { set; get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<TomatoList> tomatolist { get; set; }

        public WorkPlan(string wname, long num, List<TomatoList> list)
        {
            tomatolist = list;
            workName = wname;
            NumofDay = num;
        }
    }
}
