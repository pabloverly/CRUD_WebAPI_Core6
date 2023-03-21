
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Model;

namespace webapi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }
     
        //lista dos usuarios
        public async Task<IEnumerable<Usuario>> GetUsers()
        {
           return await _context.Usuarios.ToListAsync();
        }
        //buscar usuario por id
        public async Task<Usuario> GetUser(int id)
        {
             return await _context.Usuarios.
                Where(x  => x.Id == id).FirstOrDefaultAsync();
        }      

        public void addUser(Usuario user)
        {
           _context.Add(user);
        }
      
        public void updateUser(Usuario user)
        {
            throw new NotImplementedException();
        }
        public void deleteUser(Usuario user)
        {
            throw new NotImplementedException();
        }      
        public async Task<bool> SalvechangerAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}