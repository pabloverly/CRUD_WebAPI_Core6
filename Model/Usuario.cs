namespace webapi.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set;    }
        public string? Email { get; set; }
        
    }
}