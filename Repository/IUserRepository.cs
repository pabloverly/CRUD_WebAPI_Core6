using webapi.Model;

namespace webapi.Repository
{
    //MEUS CONTRATOS
    public interface IUserRepository
    {
        //Task mode de assincrono
        Task<IEnumerable<Usuario>> GetUsers();
        
        Task<Usuario> GetUser(int id);
        void addUser(Usuario user);
        void updateUser(Usuario user);
        void deleteUser(Usuario user);
        Task<bool> SalvechangerAsync()
        {
            throw new NotImplementedException();
        }
    }
}