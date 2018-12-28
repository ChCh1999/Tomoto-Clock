namespace TomatoClock
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("historylist.tcondition")]
    public partial class TCondition
    {
        [Key]
        [Column(Order = 0,TypeName ="int")]
        public int con { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long toid { get; set; }

        public virtual TomatoList tomatolist { get; set; }

        public TCondition()
        {
            con = 0;
        }
    }
}
