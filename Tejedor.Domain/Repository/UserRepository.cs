using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository.Interfaces;

namespace Tejedor.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TejedorDBContext _dbContext;
        public UserRepository(TejedorDBContext context) 
        {
            _dbContext = context;
        }

        async Task<IEnumerable<User>> IUserRepository.GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        async Task<User?> IUserRepository.GetUser(string UserName)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == UserName);
        }

        async Task<User?> IUserRepository.GetUser(int UserID)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.UserID == UserID);
        }

        async Task IUserRepository.AddUsers(IEnumerable<User> users)
        {
            _dbContext.Users.AddRange(users);
            await _dbContext.SaveChangesAsync();
        }

        async Task IUserRepository.AddUser(User user)
        {
            _dbContext.Users.AddRange(user);
            await _dbContext.SaveChangesAsync();
        }

        async Task<bool> IUserRepository.UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            var changes = await _dbContext.SaveChangesAsync();
            return changes > 0;
        }

        async Task IUserRepository.UpdateUsers(IEnumerable<User> users)
        {
            _dbContext.Users.UpdateRange(users);
            await _dbContext.SaveChangesAsync();
        }

        async Task IUserRepository.DeleteUsers(IEnumerable<User> users)
        {
            _dbContext.Users.RemoveRange(users);
            await _dbContext.SaveChangesAsync();
        }

        // Implementa este método para obtener el usuario de la base de datos
        public async Task<User?> LoginUser(string username, string password)
        {
            // Aquí debes implementar la lógica para obtener el usuario de tu base de datos
            // Este es solo un ejemplo simplificado
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.UserName == username && u.UserPassword == password);
        }

        public async Task<User?> RegisterUser(
            string username, string userpassword, string userEmail,
            string userAddress, string userBillingAddress, string userPhone)
        {
            // Verificar si el usuario ya existe
            var existingUser = await _dbContext.Users.SingleOrDefaultAsync(u => u.UserName == username);
            if (existingUser != null)
            {
                // Retornar null si el usuario ya existe
                return null;
            }

            // Crear una nueva instancia de usuario
            var newUser = new User
            {
                UserName = username,
                UserPassword = userpassword, // Asegúrate de que las contraseñas se manejen de forma segura
                UserEmail = userEmail,
                Address = userAddress,
                BillingAddress = userBillingAddress,
                Phone = userPhone,
                ACoins = 0,
            };

            // Agregar el nuevo usuario al contexto
            await _dbContext.Users.AddAsync(newUser);

            // Guardar los cambios en la base de datos
            await _dbContext.SaveChangesAsync();

            // Devolver el usuario recién creado
            return newUser;
        }

    }
}
