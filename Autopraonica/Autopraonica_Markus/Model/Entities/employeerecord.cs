namespace Autopraonica_Markus.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("markus.employeerecord")]
    public partial class employeerecord
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Employee_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime LoginTime { get; set; }

        public DateTime? LogoutTime { get; set; }

        public virtual employee employee { get; set; }
    }
}
