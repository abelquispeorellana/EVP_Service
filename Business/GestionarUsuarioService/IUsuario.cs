using GestionarUsuarioService.Dominio;
using GestionarUsuarioService.Errores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GestionarUsuarioService
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
        [WebInvoke(Method = "PUT", UriTemplate = "Usuario", ResponseFormat = WebMessageFormat.Json)]
        UsuarioDOM Modificar(UsuarioDOM Parametro);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Usuario/{IdUsuario}", ResponseFormat = WebMessageFormat.Json)]
        string Eliminar(string IdUsuario);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Usuario", ResponseFormat = WebMessageFormat.Json)]
        List<UsuarioDOM> Listar();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ValidarPIN/{NumDocumento}/{PIN}", ResponseFormat = WebMessageFormat.Json)]
        string ValidarPIN(string NumDocumento, string PIN);
    }
}
