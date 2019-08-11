using GestionarEstacionamientoService.Dominio;
using GestionarEstacionamientoService.Errores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GestionarEstacionamientoService
{
    [ServiceContract]
    public interface IEstacionamiento
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Estacionamiento", ResponseFormat = WebMessageFormat.Json)]
        EstacionamientoDOM Crear(EstacionamientoDOM Parametro);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Estacionamiento/{IdUsuario}", ResponseFormat = WebMessageFormat.Json)]
        EstacionamientoDOM Obtener(string IdUsuario);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Estacionamiento", ResponseFormat = WebMessageFormat.Json)]
        EstacionamientoDOM Modificar(EstacionamientoDOM Parametro);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Estacionamiento/{IdEstacimionamiento}", ResponseFormat = WebMessageFormat.Json)]
        string Eliminar(string IdEstacimionamiento);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Estacionamiento", ResponseFormat = WebMessageFormat.Json)]
        List<EstacionamientoDOM> Listar();
    }
}
