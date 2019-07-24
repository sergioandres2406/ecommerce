namespace ecommerce.Web.Data
{
    //aqui es para poder acceder a la clase, ya que está
    //en la carpeta Entities
    using ecommerce.Web.Data.Entities;

    //esta libreria es el framework de entity core,
    //sirve para utilizar los métodos de del CRUD en la bd

    using Microsoft.EntityFrameworkCore;

    
    public class DataContext : DbContext
    {
        //declaramos un objeto DbSet para la tabla Products
        public DbSet<Product> Products { get; set; }

        // el constructor Datacontext recibe de DbcontextOptions
        //y ese options se lo pasamos al contructor base
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }
    }
}
