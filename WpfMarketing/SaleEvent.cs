//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfMarketing
{
    using System;
    using System.Collections.Generic;
    
    public partial class SaleEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SaleEvent()
        {
            this.SaleEventSingleProducts = new HashSet<SaleEventSingleProduct>();
            this.SaleEventQuotas = new HashSet<SaleEventQuota>();
            this.SaleEventComboes = new HashSet<SaleEventCombo>();
        }
    
        public Nullable<int> SupplierID { get; set; }
        public int SaleEventID { get; set; }
        public string SaleEventTitle { get; set; }
        public string SaleEventContent { get; set; }
        public Nullable<System.DateTime> SaleEventStart { get; set; }
        public Nullable<System.DateTime> SaleEventEnd { get; set; }
        public Nullable<System.DateTime> EdditTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleEventSingleProduct> SaleEventSingleProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleEventQuota> SaleEventQuotas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleEventCombo> SaleEventComboes { get; set; }
    }
}
