using projetoLojaAsp.Models;

namespace projetoLojaAsp.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly string _connectionString;

        public UsuarioRepositorio(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("DefaultConnection");
        
        public AdicionarUsuario(Usuario usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO Usuarios (name, email, senha) VALUES (@name, @email, @password)";
                cmd.Parameters.AddWithValue("@name", usuario.name);
                cmd.Parameters.AddWithValue("@email", usuario.email);
                cmd.Parameters.AddWithValue("@password", usuario.password);
                cmd.ExecuteNonQuery();


            }

        }
    }
}
