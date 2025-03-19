using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        TestarConexao(); // Chamar o teste de conexão ao iniciar
    }

    public DbSet<Customer> Customers { get; set; }

    public void TestarConexao()
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=Susteni;Trusted_Connection=True;";

        using (var connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("✅ Conexão com o banco de dados bem-sucedida!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro ao conectar ao banco: {ex.Message}");
            }
        }
    }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}
