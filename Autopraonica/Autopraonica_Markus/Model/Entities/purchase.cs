namespace Autopraonica_Markus.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("markus.purchase")]
    public partial class purchase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public purchase()
        {
            purchaseitems = new HashSet<purchaseitem>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string PurchaseNumber { get; set; }

        [Required]
        [StringLength(150)]
        public string SupplierName { get; set; }

        public DateTime PurchaseTime { get; set; }

        public int Employee_Id { get; set; }

        public bool? Canceled { get; set; }

        public virtual employee employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<purchaseitem> purchaseitems { get; set; }
    }
}
