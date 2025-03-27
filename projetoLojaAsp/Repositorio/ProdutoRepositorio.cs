namespace projetoLojaAsp.Repositorio
{
    public class ProdutoRepositorio
    {
        private readonly string _connectionString;

        public ProdutoRepositorio(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
}
