using EVP.Libreria;
using GestionarCredencialService.Dominio;
using GestionarCredencialService.Errores;
using System.ServiceModel.Web;

namespace GestionarCredencialService
{
    public class Usuario : IUsuario
    {  

        public UsuarioDOM UsuarioAutenticar(string NumDocumento, string Contrasenia)
        {
            try
            {
                return (new RestClient<UsuarioDOM>().GET("http://sharedcss.com/evp/application/UsuarioService/Usuario.svc/UsuarioAutenticar/" + NumDocumento + "/" + Contrasenia).GetAwaiter().GetResult());

            }
            catch (System.Net.WebException ex)
            {
                var RestClientException = ex.Serializer(); 
                throw new WebFaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = RestClientException.Codigo,
                            Descripcion = RestClientException.Descripcion
                        },
                        System.Net.HttpStatusCode.Conflict
                    );
            }
        }
    }
}
