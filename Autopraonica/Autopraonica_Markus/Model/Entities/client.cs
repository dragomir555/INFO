namespace Autopraonica_Markus.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("markus.client")]
    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            contracts = new HashSet<contract>();
            legalentityservices = new HashSet<legalentityservice>();
            receipts = new HashSet<receipt>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(13)]
        public string UID { get; set; }

        [Required]
        [StringLength(45)]
        public string Address { get; set; }

        public int City_Id { get; set; }

        public virtual city city { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contract> contracts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<legalentityservice> legalentityservices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<receipt> receipts { get; set; }
    }
}
