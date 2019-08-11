using System.Configuration;

namespace AdministradorService
{
    public class Local
    {
        public static string ConnectionString { get { return ConfigurationManager.ConnectionStrings["cnx"].ConnectionString; } }
    } 
}