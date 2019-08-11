using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UsuarioService.Dominio;
using UsuarioService.Errores;

namespace UsuarioService
{
    [ServiceContract]
    public interface IUsuario
    {

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Usuario", ResponseFormat = WebMessageFormat.Json)]
        UsuarioDOM Crear(UsuarioDOM Parametro);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Usuario/{NumDocumento}", ResponseFormat = WebMessageFormat.Json)]
        UsuarioDOM Obtener(string NumDocumento);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "UsuarioAutenticar/{NumDocumento}/{Contrasenia}", ResponseFormat = WebMessageFormat.Json)]
        UsuarioDOM UsuarioAutenticar(string NumDocumento, string Contrasenia);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Usuario", ResponseFormat = WebMessageFormat.Json)]
        UsuarioDOM Modificar(UsuarioDOM Parametro);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Usuario/{IdUsuario}", ResponseFormat = WebMessageFormat.Json)]
        string Eliminar(string IdUsuario);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Usuario", ResponseFormat = WebMessageFormat.Json)]
        List<UsuarioDOM> Listar();
    }
}
