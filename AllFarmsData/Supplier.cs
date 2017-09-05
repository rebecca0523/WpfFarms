//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllFarmsData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            this.ActivityFarmers = new HashSet<ActivityFarmer>();
            this.Advertisings = new HashSet<Advertising>();
            this.CustomerSubscriptions = new HashSet<CustomerSubscription>();
            this.Products = new HashSet<Product>();
            this.SaleEvents = new HashSet<SaleEvent>();
            this.SuppliersBulletinBoards = new HashSet<SuppliersBulletinBoard>();
            this.SuppliersFarms = new HashSet<SuppliersFarm>();
            this.SuppliersStoryMasters = new HashSet<SuppliersStoryMaster>();
            this.SuppliersVedios = new HashSet<SuppliersVedio>();
            this.SystemToSuppliersInfoes = new HashSet<SystemToSuppliersInfo>();
        }
    
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactName1 { get; set; }
        public string ContactName2 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string LineID { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedUserID { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<int> LastUpdateUserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityFarmer> ActivityFarmers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Advertising> Advertisings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerSubscription> CustomerSubscriptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleEvent> SaleEvents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuppliersBulletinBoard> SuppliersBulletinBoards { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuppliersFarm> SuppliersFarms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuppliersStoryMaster> SuppliersStoryMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuppliersVedio> SuppliersVedios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemToSuppliersInfo> SystemToSuppliersInfoes { get; set; }
    }
}
