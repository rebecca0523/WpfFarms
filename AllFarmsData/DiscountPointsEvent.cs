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
    
    public partial class DiscountPointsEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiscountPointsEvent()
        {
            this.DiscountPointsEventDetails = new HashSet<DiscountPointsEventDetail>();
        }
    
        public int DiscountPointsEventID { get; set; }
        public string DiscountPointsEventName { get; set; }
        public string DiscountPointsEvenContent { get; set; }
        public System.DateTime DiscountPointsEventStart { get; set; }
        public System.DateTime DiscountPointsEventEnd { get; set; }
        public Nullable<int> BirthdayPoint { get; set; }
        public Nullable<int> LoginPoint { get; set; }
        public Nullable<int> SharePoint { get; set; }
        public Nullable<decimal> Quota { get; set; }
        public Nullable<int> QuotaPoint { get; set; }
        public int QPointToOneNTD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiscountPointsEventDetail> DiscountPointsEventDetails { get; set; }
    }
}
