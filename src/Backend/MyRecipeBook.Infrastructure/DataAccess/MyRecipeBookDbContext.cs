using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Infrastructure.DataAccess;

public class MyRecipeBookDbContext : DbContext
{
    public MyRecipeBookDbContext(DbContextOptions options) : base(options)
    {

    }

    /* Acessar a tabela do usuário */
    public DbSet<User> Users { get; set; }

    /* Especificando onde que vai ficar a classe de configurações */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyRecipeBookDbContext).Assembly);
    }
}
