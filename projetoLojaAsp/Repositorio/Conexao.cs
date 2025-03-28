using MySql.Data.MySqlClient;
using System.Data;

namespace projetoLojaAsp.Repositorio
{
    public class Conexao: IDisposable
 {
        private readonly MySqlConnection _connection;

        public Conexao(string connectionString)
            {
        try
            {
             
               
                _connection = new MySqlConnection(connectionString);
                  _connection.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco: {ex.Message}");
                throw; // Lança novamente a exceção para ver no log
            }
        }
        public MySqlCommand MySqlCommand()
        {
            return _connection.CreateCommand();
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }

}




