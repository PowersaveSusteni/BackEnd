using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Exemplo de uma tabela no banco de dados
    public DbSet<Customer> Customers { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}
