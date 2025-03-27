﻿namespace projetoLojaAsp.Repositorio
{
    public class ProdutoRepositorio
    {
        private readonly string _connectionString;

        public ProdutoRepositorio(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("DefaultConnection");

        public void AdicionarProduto(Produto produto )
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO Produtos (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha)";
                cmd.Parameters.AddWithValue("@name", produto.name);
                cmd.Parameters.AddWithValue("@description", produto.description);
                cmd.Parameters.AddWithValue("@price", produto.price);
                cmd.ExecuteNonQuery();


            }


        }
    }
}
