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
    }
}