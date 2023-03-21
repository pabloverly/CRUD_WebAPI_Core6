
using Microsoft.EntityFrameworkCore;
using webapi.Model;

namespace webapi.Data
{
    public class UserContext: DbContext
    {
         public UserContext(DbContextOptions <UserContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }

        //customisar as configurações do banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var usuario = modelBuilder.Entity<Usuario>();
            usuario.ToTable("tb_Usuario");
            usuario.HasKey(x => x.Id);
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(x => x.Nome).HasColumnName("nome").ValueGeneratedOnAdd().IsRequired();
            usuario.Property(x => x.DataNascimento).HasColumnName("dtNascimento").ValueGeneratedOnAdd();
            usuario.Property(x => x.Email).HasColumnType("text");
        }
        
    }
}