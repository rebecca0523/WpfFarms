//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfFarmsProducts
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductImages = new HashSet<ProductImage>();
        }
    
        public int ProductID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public string ProductName { get; set; }
        public Nullable<System.DateTime> SellStartDate { get; set; }
        public Nullable<System.DateTime> SellEndDate { get; set; }
        public Nullable<decimal> MarkPrice { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<bool> PreOrder { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public string ProductDescription { get; set; }
        public Nullable<int> TotalQTY { get; set; }
        public Nullable<int> CanSaleQTY { get; set; }
        public Nullable<int> QuantitySold { get; set; }
        public Nullable<bool> Discounted { get; set; }
        public Nullable<bool> DiscountedAB { get; set; }
        public Nullable<bool> DiscountedQuota { get; set; }
        public Nullable<bool> DiscountedPoint { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public string LastUpdateUserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
