﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class farmsDBEntities : DbContext
    {
        public farmsDBEntities()
            : base("name=farmsDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActivityCity> ActivityCity { get; set; }
        public virtual DbSet<ActivityFarmer> ActivityFarmer { get; set; }
        public virtual DbSet<ActivityOrder> ActivityOrder { get; set; }
        public virtual DbSet<ActivityPhoto> ActivityPhoto { get; set; }
        public virtual DbSet<AddressInfo> AddressInfo { get; set; }
        public virtual DbSet<Advertising> Advertising { get; set; }
        public virtual DbSet<BlackListInfo> BlackListInfo { get; set; }
        public virtual DbSet<Browse> Browse { get; set; }
        public virtual DbSet<ChatLog> ChatLog { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }
        public virtual DbSet<CustomerLoginlog> CustomerLoginlog { get; set; }
        public virtual DbSet<CustomerRefund> CustomerRefund { get; set; }
        public virtual DbSet<CustomerReturn> CustomerReturn { get; set; }
        public virtual DbSet<CustomerSubscription> CustomerSubscription { get; set; }
        public virtual DbSet<DiscountPointsEvent> DiscountPointsEvent { get; set; }
        public virtual DbSet<DiscountPointsEventDetail> DiscountPointsEventDetail { get; set; }
        public virtual DbSet<DiscountPointsRec> DiscountPointsRec { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PostalCodeInfo> PostalCodeInfo { get; set; }
        public virtual DbSet<ProductGrowPlanDetail> ProductGrowPlanDetail { get; set; }
        public virtual DbSet<ProductGrowPlanMaster> ProductGrowPlanMaster { get; set; }
        public virtual DbSet<ProductImages> ProductImages { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<SaleEvent> SaleEvent { get; set; }
        public virtual DbSet<SaleEventCombo> SaleEventCombo { get; set; }
        public virtual DbSet<SaleEventQuota> SaleEventQuota { get; set; }
        public virtual DbSet<SaleEventSingleProduct> SaleEventSingleProduct { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<SuppliersBulletinBoard> SuppliersBulletinBoard { get; set; }
        public virtual DbSet<SuppliersFarm> SuppliersFarm { get; set; }
        public virtual DbSet<SuppliersStoryDetail> SuppliersStoryDetail { get; set; }
        public virtual DbSet<SuppliersStoryMaster> SuppliersStoryMaster { get; set; }
        public virtual DbSet<SuppliersVedio> SuppliersVedio { get; set; }
        public virtual DbSet<SuppliersVideo> SuppliersVideo { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<SystemToSuppliersInfo> SystemToSuppliersInfo { get; set; }
    
        public virtual int checkidentity(string email, string name)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("checkidentity", emailParameter, nameParameter);
        }
    
        public virtual int editpassword(string email, string name, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("editpassword", emailParameter, nameParameter, passwordParameter);
        }
    
        public virtual int Insert(ObjectParameter customerID, string password, string name, string gender, string phone, string mobile, Nullable<int> evaluation, string addressID, string email, Nullable<int> useridentity, Nullable<System.DateTime> creationDate, Nullable<System.DateTime> lastUpdate)
        {
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var mobileParameter = mobile != null ?
                new ObjectParameter("Mobile", mobile) :
                new ObjectParameter("Mobile", typeof(string));
    
            var evaluationParameter = evaluation.HasValue ?
                new ObjectParameter("Evaluation", evaluation) :
                new ObjectParameter("Evaluation", typeof(int));
    
            var addressIDParameter = addressID != null ?
                new ObjectParameter("AddressID", addressID) :
                new ObjectParameter("AddressID", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var useridentityParameter = useridentity.HasValue ?
                new ObjectParameter("Useridentity", useridentity) :
                new ObjectParameter("Useridentity", typeof(int));
    
            var creationDateParameter = creationDate.HasValue ?
                new ObjectParameter("CreationDate", creationDate) :
                new ObjectParameter("CreationDate", typeof(System.DateTime));
    
            var lastUpdateParameter = lastUpdate.HasValue ?
                new ObjectParameter("LastUpdate", lastUpdate) :
                new ObjectParameter("LastUpdate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert", customerID, passwordParameter, nameParameter, genderParameter, phoneParameter, mobileParameter, evaluationParameter, addressIDParameter, emailParameter, useridentityParameter, creationDateParameter, lastUpdateParameter);
        }
    
        public virtual int login(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("login", emailParameter, passwordParameter);
        }
    
        public virtual int login1(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("login1", emailParameter, passwordParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
