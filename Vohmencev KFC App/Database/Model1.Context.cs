//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vohmencev_KFC_App.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Vohmencev_KFCEntities : DbContext
    {
        public Vohmencev_KFCEntities()
            : base("name=Vohmencev_KFCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<DishType> DishType { get; set; }
        public virtual DbSet<Ingridients> Ingridients { get; set; }
        public virtual DbSet<OrderContent> OrderContent { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
