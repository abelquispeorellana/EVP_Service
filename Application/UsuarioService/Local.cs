using System.Configuration;

namespace UsuarioService
{
    public class Local
    {
        public static string ConnectionString { get { return ConfigurationManager.ConnectionStrings["cnx"].ConnectionString; } }
    }
}