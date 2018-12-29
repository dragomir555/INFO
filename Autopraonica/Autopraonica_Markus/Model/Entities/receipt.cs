namespace Autopraonica_Markus.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("markus.receipt")]
    public partial class receipt
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateTo { get; set; }

        [Column(TypeName = "blob")]
        [Required]
        public byte[] PDF { get; set; }

        public sbyte Paid { get; set; }

        public int Client_Id { get; set; }

        public int Manager_Id { get; set; }

        [Column(TypeName = "blob")]
        public byte[] PDF_TABLE { get; set; }

        public virtual client client { get; set; }

        public virtual manager manager { get; set; }
    }
}
