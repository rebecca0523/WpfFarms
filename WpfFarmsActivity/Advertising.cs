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
    
    public partial class Advertising
    {
        public int SupplierID { get; set; }
        public int AdvertisingID { get; set; }
        public string AdvertisingITitle { get; set; }
        public string AdvertisingIContent { get; set; }
        public System.DateTime AdvertisingStarTime { get; set; }
        public System.DateTime AdvertisingEndTime { get; set; }
        public byte[] AdvertisingPhoto { get; set; }
        public bool AlreadyPaid { get; set; }
        public string AdvertisingLink { get; set; }
        public Nullable<System.DateTime> EdditTime { get; set; }
    
        public virtual Suppliers Suppliers { get; set; }
    }
}
