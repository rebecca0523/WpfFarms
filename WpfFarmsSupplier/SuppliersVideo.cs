//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfFarmsSupplier
{
    using System;
    using System.Collections.Generic;
    
    public partial class SuppliersVideo
    {
        public int SuppliersVideoID { get; set; }
        public int SuppliersID { get; set; }
        public string SuppliersStoryTitle { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public byte[] VideoFile { get; set; }
        public string VideomimeType { get; set; }
        public string VideoName { get; set; }
        public Nullable<int> CreatedUserID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> LastUpdateUserID { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
    
        public virtual Supplier Supplier { get; set; }
    }
}
