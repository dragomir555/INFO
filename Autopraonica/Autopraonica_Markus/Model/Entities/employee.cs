namespace Autopraonica_Markus.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("markus.employee")]
    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            employments = new HashSet<employment>();
            helpingemployeerecords = new HashSet<helpingemployeerecord>();
            helpingemployeerecords1 = new HashSet<helpingemployeerecord>();
            employeerecords = new HashSet<employeerecord>();
            purchases = new HashSet<purchase>();
            naturalentityservices = new HashSet<naturalentityservice>();
            naturalentityservices1 = new HashSet<naturalentityservice>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(45)]
        public string LastName { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(13)]
        public string PID { get; set; }

        [Column("E-mail")]
        [Required]
        [StringLength(45)]
        public string E_mail { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(45)]
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employment> employments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<helpingemployeerecord> helpingemployeerecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<helpingemployeerecord> helpingemployeerecords1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employeerecord> employeerecords { get; set; }

        public virtual manager manager { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<purchase> purchases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<naturalentityservice> naturalentityservices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<naturalentityservice> naturalentityservices1 { get; set; }
    }
}
