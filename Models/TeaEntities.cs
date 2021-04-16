namespace TeaMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TeaEntities : DbContext
    {
        
        public TeaEntities()
            : base("name=TeaEntities")
        {
          /*  this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;*/
        }

        
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Tea> Teas { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Sup> Sups { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}