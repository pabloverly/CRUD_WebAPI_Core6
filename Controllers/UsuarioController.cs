using Microsoft.AspNetCore.Mvc;
using webapi.Repository;
using webapi.Model;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class UsuarioController : ControllerBase

    {
        private IUserRepository _userRepository;

        public UsuarioController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
      
        //passar manualmente os dados 
        //private static List<Model.Usuario> Usuarios(){    
        //     return new List<Model.Usuario>{
        //         new Model.Usuario{
        //             Id = 1,
        //             Nome = "João",
        //             DataNascimento = new System.DateTime(1990, 1, 1)
        //         },
                
        //     };
        // }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _userRepository.GetUsers(); 
            return usuarios.Any()? Ok(usuarios): NoContent();
        }   

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById( int id)
        {
            var usuario = await _userRepository.GetUser(id); 
            return usuario != null
                ? Ok(usuario)
                : NotFound("Usuário não encontrado");
        }  

        [HttpPost]
         public async Task<IActionResult> Post(Usuario usuario)
        {
            _userRepository.addUser(usuario);
            return await _userRepository.SalvechangerAsync()
            ? Ok("User inserido com sucesso")
            : BadRequest("Erro ao inserir o usuário"); 
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            var user = await _userRepository.GetUser(id);
            if(user == null)
            {
                return NotFound("Usuário não encontrado");
            }
            user.Nome = usuario.Nome ?? user.Nome;
            user.DataNascimento = usuario.DataNascimento != new DateTime() 
                    ? usuario.DataNascimento 
                    : user.DataNascimento;
            user.Email = usuario.Email ?? user.Email;

            _userRepository.updateUser(user);

            return await _userRepository.SalvechangerAsync()?
                Ok("Usuário atualizado com sucesso")
                : BadRequest("Erro ao atualizar o usuário");           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepository.GetUser(id);

            if(user == null)
            {
                return NotFound("Usuário não encontrado");
            }

            _userRepository.deleteUser(user);
            return await _userRepository.SalvechangerAsync()?
                Ok("Usuário deletado com sucesso")
                : BadRequest("Erro ao deletar o usuário");
        }
    }
}