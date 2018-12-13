namespace Autopraonica_Markus.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("markus.employment")]
    public partial class employment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Employee_Id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        [Required]
        [StringLength(45)]
        public string UserName { get; set; }

        [Required]
        [StringLength(45)]
        public string HashPassword { get; set; }

        [Required]
        [StringLength(10)]
        public string Salt { get; set; }

        public sbyte FirstLogin { get; set; }

        public virtual employee employee { get; set; }
    }
}
