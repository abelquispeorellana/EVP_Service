using System.Configuration;

namespace AlquilerService
{
    public class Local
    {
        public static string ConnectionString { get { return ConfigurationManager.ConnectionStrings["cnx"].ConnectionString; } }
    }
}