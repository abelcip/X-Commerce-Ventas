namespace Aplicacion.Conexion
{
    public static class CadenaConexion
    {
        private const string BaseDatos = "Esquelo";
        private const string Servidor = "LAPTOP-LIJI9L6Q\\SQLEXPRESS";
        private const string Usuario = "sa";
        private const string Password = "12345678";

        public static string ObtenerCadenaConexion => $"Data Source ={Servidor}; " +
                                                      $"Initial Catalog={BaseDatos}; " +
                                                      $"User Id={Usuario}; " +
                                                      $"Password={Password};";
    }
}
