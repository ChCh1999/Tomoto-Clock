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
        public short wpid { get; set; }

        [Required]
        [StringLength(20)]
        public string workName { get; set; }

        [Required]
        [StringLength(8)]
        public string startTime { get; set; }

        public short NumofDay { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(8)]
        public String StartDay { set; get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<TomatoList> tomatolist { get; set; }

        public WorkPlan(string wname, string startTime, short NofDay, List<TomatoList> lists)
        {
            workName = wname;
            this.startTime = startTime;
            NumofDay = NofDay;
            tomatolist = lists;
        }
    }
}
