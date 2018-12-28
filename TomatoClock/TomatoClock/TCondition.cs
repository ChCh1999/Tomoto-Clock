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
        public short tcid { get; set; }

        public short? toid { get; set; }

        public sbyte con { get; set; }

        public virtual TomatoList tomatolist { get; set; }

        public TCondition()
        {
            con = 0;
        }
    }
}
