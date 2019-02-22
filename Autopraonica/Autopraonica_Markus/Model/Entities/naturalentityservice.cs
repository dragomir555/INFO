namespace Autopraonica_Markus.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("markus.naturalentityservice")]
    public partial class naturalentityservice
    {
        public int Id { get; set; }

        public DateTime ServiceTime { get; set; }

        public decimal Price { get; set; }

        public int CarBrand_Id { get; set; }

        public int PricelistItem_Id { get; set; }

        public int Employee_Id { get; set; }

        public int? HelpingEmployee_Id { get; set; }

        public bool? Canceled { get; set; }

        public virtual carbrand carbrand { get; set; }

        public virtual employee employee { get; set; }

        public virtual employee employee1 { get; set; }

        public virtual legalentityservice legalentityservice { get; set; }

        public virtual pricelistitem pricelistitem { get; set; }
    }
}
