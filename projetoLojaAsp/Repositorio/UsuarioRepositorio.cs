using projetoLojaAsp.Models;

namespace projetoLojaAsp.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly string _connectionString;

        public UsuarioRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "INSERT INTO Usuario (name, email, password) VALUES (@name, @email, @password)";
                cmd.Parameters.AddWithValue("@name", usuario.name);
                cmd.Parameters.AddWithValue("@email", usuario.email);
                cmd.Parameters.AddWithValue("@password", usuario.password);
                cmd.ExecuteNonQuery();


            }

        }
        public Usuario ObterUsuario(string email)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Usuario WHERE Email = @Email";
                cmd.Parameters.AddWithValue("@email", email);
    

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            id = reader.GetInt32("id"),
                            name = reader.GetString("name"),
                            email = reader.GetString("email"),
                            password = reader.GetString("password"),

                        };

                    }

                }
                return null;
            }
        }
    }
}
