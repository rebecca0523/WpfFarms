//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfFarmsActivity
{
    using System;
    using System.Collections.Generic;
    
    public partial class SuppliersFarm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuppliersFarm()
        {
            this.ProductGrowPlanMaster = new HashSet<ProductGrowPlanMaster>();
        }
    
        public int SupplierFarmID { get; set; }
        public int SupplierID { get; set; }
        public string SupplierFarmDESC { get; set; }
        public string FarmSoilKind { get; set; }
        public string FarmSoilRange { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedDateUserID { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<int> LastUpdateUserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductGrowPlanMaster> ProductGrowPlanMaster { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}
