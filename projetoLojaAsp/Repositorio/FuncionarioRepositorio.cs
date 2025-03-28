using projetoLojaAsp.Models;

namespace projetoLojaAsp.Repositorio
{
    public class FuncionarioRepositorio
    {
        private readonly string _connectionString;

        public FuncionarioRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "INSERT INTO Funcionario (name, email, password) VALUES (@name, @email, @password)";
                cmd.Parameters.AddWithValue("@name", funcionario.name);
                cmd.Parameters.AddWithValue("@email", funcionario.email);
                cmd.Parameters.AddWithValue("@password", funcionario.password);
                cmd.ExecuteNonQuery();


            }
            
        }
        public Funcionario ObterFuncionario(string email)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Funcionario WHERE email = @email";
                cmd.Parameters.AddWithValue("@email", email);


                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Funcionario
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

