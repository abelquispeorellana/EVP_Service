using System.Configuration;

namespace EstacionamientoService
{
    public class Local
    {
        public static string ConnectionString { get { return "Server=tcp:evp.database.windows.net,1433;Initial Catalog=EVP;Persist Security Info=False;User ID=abelquispeorellana;Password=A#&aaa2019;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; } }
    }
}