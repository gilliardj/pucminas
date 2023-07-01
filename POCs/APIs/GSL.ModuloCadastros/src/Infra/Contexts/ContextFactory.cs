using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Contexts
{
    public class ContextFactory : IDesignTimeDbContextFactory<CadastroDbContext>
    {
        public CadastroDbContext CreateDbContext(string[] args)
        {
            const string connectionString = "Server=localhost;Port=3306;Database=db;Uid=root;Pwd=senha_do_root;";
            var optionsBuilder = new DbContextOptionsBuilder<CadastroDbContext>();
            optionsBuilder.UseMySQL(connectionString);
            return new CadastroDbContext(optionsBuilder.Options);
        }
    }
}