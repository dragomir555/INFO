namespace Autopraonica_Markus.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("markus.pricelistitem")]
    public partial class pricelistitem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pricelistitem()
        {
            naturalentityservices = new HashSet<naturalentityservice>();
        }

        public int Id { get; set; }

        public int ServiceType_Id { get; set; }

        public int PricelistItemName_Id { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        public sbyte Current { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<naturalentityservice> naturalentityservices { get; set; }

        public virtual pricelistitemname pricelistitemname { get; set; }

        public virtual servicetype servicetype { get; set; }
    }
}
