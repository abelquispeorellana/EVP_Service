using System.Configuration;

namespace EstacionamientoService
{
    public class Local
    {
        public static string ConnectionString { get { return ConfigurationManager.ConnectionStrings["cnx"].ConnectionString; } }
    }
}