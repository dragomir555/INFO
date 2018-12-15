namespace Autopraonica_Markus.Model.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MarkusDb : DbContext
    {
        public MarkusDb()
            : base("name=MarkusDb1")
        {
        }

        public virtual DbSet<carbrand> carbrands { get; set; }
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<contract> contracts { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<employeerecord> employeerecords { get; set; }
        public virtual DbSet<employment> employments { get; set; }
        public virtual DbSet<helpingemployeerecord> helpingemployeerecords { get; set; }
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<legalentityservice> legalentityservices { get; set; }
        public virtual DbSet<manager> managers { get; set; }
        public virtual DbSet<naturalentityservice> naturalentityservices { get; set; }
        public virtual DbSet<pricelistitem> pricelistitems { get; set; }
        public virtual DbSet<pricelistitemname> pricelistitemnames { get; set; }
        public virtual DbSet<purchase> purchases { get; set; }
        public virtual DbSet<purchaseitem> purchaseitems { get; set; }
        public virtual DbSet<receipt> receipts { get; set; }
        public virtual DbSet<servicetype> servicetypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<carbrand>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<carbrand>()
                .HasMany(e => e.naturalentityservices)
                .WithRequired(e => e.carbrand)
                .HasForeignKey(e => e.CarBrand_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<city>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .Property(e => e.PostCode)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .HasMany(e => e.clients)
                .WithRequired(e => e.city)
                .HasForeignKey(e => e.City_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.UID)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.contracts)
                .WithRequired(e => e.client)
                .HasForeignKey(e => e.Client_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.legalentityservices)
                .WithRequired(e => e.client)
                .HasForeignKey(e => e.Client_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.receipts)
                .WithRequired(e => e.client)
                .HasForeignKey(e => e.Client_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.PID)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.E_mail)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.employments)
                .WithRequired(e => e.employee)
                .HasForeignKey(e => e.Employee_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.helpingemployeerecords)
                .WithRequired(e => e.employee)
                .HasForeignKey(e => e.Employee_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.helpingemployeerecords1)
                .WithRequired(e => e.employee1)
                .HasForeignKey(e => e.HelpingEmployee_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.employeerecords)
                .WithRequired(e => e.employee)
                .HasForeignKey(e => e.Employee_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasOptional(e => e.manager)
                .WithRequired(e => e.employee);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.purchases)
                .WithRequired(e => e.employee)
                .HasForeignKey(e => e.Employee_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.naturalentityservices)
                .WithRequired(e => e.employee)
                .HasForeignKey(e => e.Employee_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.naturalentityservices1)
                .WithOptional(e => e.employee1)
                .HasForeignKey(e => e.HelpingEmployee_Id);

            modelBuilder.Entity<employment>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<employment>()
                .Property(e => e.HashPassword)
                .IsUnicode(false);

            modelBuilder.Entity<employment>()
                .Property(e => e.Salt)
                .IsUnicode(false);

            modelBuilder.Entity<item>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<item>()
                .Property(e => e.MeasuringUnit)
                .IsUnicode(false);

            modelBuilder.Entity<item>()
                .HasMany(e => e.purchaseitems)
                .WithRequired(e => e.item)
                .HasForeignKey(e => e.Item_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<legalentityservice>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<legalentityservice>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<legalentityservice>()
                .Property(e => e.LicencePlate)
                .IsUnicode(false);

            modelBuilder.Entity<manager>()
                .HasMany(e => e.receipts)
                .WithRequired(e => e.manager)
                .HasForeignKey(e => e.Manager_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<naturalentityservice>()
                .HasOptional(e => e.legalentityservice)
                .WithRequired(e => e.naturalentityservice);

            modelBuilder.Entity<pricelistitem>()
                .HasMany(e => e.naturalentityservices)
                .WithRequired(e => e.pricelistitem)
                .HasForeignKey(e => e.PricelistItem_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pricelistitemname>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<pricelistitemname>()
                .HasMany(e => e.pricelistitems)
                .WithRequired(e => e.pricelistitemname)
                .HasForeignKey(e => e.PricelistItemName_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<purchase>()
                .Property(e => e.PurchaseNumber)
                .IsUnicode(false);

            modelBuilder.Entity<purchase>()
                .Property(e => e.SupplierName)
                .IsUnicode(false);

            modelBuilder.Entity<purchase>()
                .HasMany(e => e.purchaseitems)
                .WithRequired(e => e.purchase)
                .HasForeignKey(e => e.Purchase_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<servicetype>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<servicetype>()
                .HasMany(e => e.pricelistitems)
                .WithRequired(e => e.servicetype)
                .HasForeignKey(e => e.ServiceType_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
