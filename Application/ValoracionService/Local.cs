using System.Configuration;

namespace ValoracionService
{
    public class Local
    {
        public static string ConnectionString { get { return ConfigurationManager.ConnectionStrings["cnx"].ConnectionString  ; } }
    }
}