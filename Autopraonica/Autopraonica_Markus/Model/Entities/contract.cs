namespace Autopraonica_Markus.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("markus.contract")]
    public partial class contract
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        public sbyte Current { get; set; }

        public int Client_Id { get; set; }

        public virtual client client { get; set; }
    }
}
