namespace Autopraonica_Markus.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("markus.legalentityservice")]
    public partial class legalentityservice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NaturalEntityService_Id { get; set; }

        [Required]
        [StringLength(45)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(45)]
        public string LastName { get; set; }

        [Required]
        [StringLength(45)]
        public string LicencePlate { get; set; }

        public int Client_Id { get; set; }

        public virtual client client { get; set; }

        public virtual naturalentityservice naturalentityservice { get; set; }
    }
}
