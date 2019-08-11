using GestionarCredencialService.Dominio;
using GestionarCredencialService.Errores;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace GestionarCredencialService
{
    [ServiceContract]
    public interface IUsuario
    {

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "UsuarioAutenticar/{NumDocumento}/{Contrasenia}", ResponseFormat = WebMessageFormat.Json)]
        UsuarioDOM UsuarioAutenticar(string NumDocumento, string Contrasenia);

    }
}
