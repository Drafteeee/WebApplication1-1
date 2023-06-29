using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Library;Trusted_Connection=true;TrustServerCertificate=true;");
        }
       
        public DbSet<Book> books { get; set; }
        
        public DbSet<Author> authors { get; set; }
       
        
        public DbSet<Ganre> ganre { get; set; } 
        public DbSet<Feedback> feedbacks { get; set; }
    }
}
