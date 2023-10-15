using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options){}
    public DbSet<Product> Products {get; set;}

    public DbSet<Category> Category {get; set;}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Product>()
            .Property(p => p.Name).HasMaxLength(50).IsRequired();
        builder.Entity<Product>()
            .Property(p => p.Code).HasMaxLength(50).IsRequired();
    }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     => optionsBuilder.UseSqlServer(
//         "Server=localhost; Database=products; User Id=sa; Password=@flatron1522; MultipleActiveResultSets=True; Encrypt=YES; TrustServerCertificate=YES");
 }

