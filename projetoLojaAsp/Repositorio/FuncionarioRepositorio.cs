using projetoLojaAsp.Models;
using System.Security.Cryptography.X509Certificates;

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
                cmd.CommandText = "INSERT INTO Usuario (name, email, password) VALUES (@name, @email, @password)";
                cmd.Parameters.AddWithValue("@name", funcionario.name);
                cmd.Parameters.AddWithValue("@email", funcionario.email);
                cmd.Parameters.AddWithValue("@password", funcionario.password);
                cmd.ExecuteNonQuery();


            }
            
        }
        public void ObterUsuario(Funcionario funcionario)
    }
}
