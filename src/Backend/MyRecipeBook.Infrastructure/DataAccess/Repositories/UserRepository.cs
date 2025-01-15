using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entites;
using MyRecipeBook.Domain.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly MyRecipeBookDbContext _dbContext;

    public UserRepository(MyRecipeBookDbContext dbContext) => _dbContext = dbContext;

    /* 
     * Adicionar Usuário
     * Coloque opções de métodos asincronos para funções que persistem/usam o banco de dados 
     */
    public async Task Add(User user) => _dbContext.Users.AddAsync(user);
    /* 
     * Verificar se já existe algum e-mail cadastrado anteriormente
     */
    public async Task<bool> ExistActiveUserWithEmail(string email) =>
        /* Qualquer resultado onde o email seja igual e esteja ativo */
        await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);


}

