using AlquilerService.Dominio;
using AlquilerService.Errores;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AlquilerService
{
    [ServiceContract]
    public interface IAlquiler
    {

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Alquiler", ResponseFormat = WebMessageFormat.Json)]
        AlquilerDOM Crear(AlquilerDOM Parametro);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Alquiler/{IdEstacimionamiento}", ResponseFormat = WebMessageFormat.Json)]
        AlquilerDOM Obtener(string IdEstacimionamiento);
        
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Alquiler", ResponseFormat = WebMessageFormat.Json)]
        AlquilerDOM Modificar(AlquilerDOM Parametro);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Alquiler/{IdAlquiler}", ResponseFormat = WebMessageFormat.Json)]
        string Eliminar(string IdAlquiler);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Alquiler", ResponseFormat = WebMessageFormat.Json)]
        List<AlquilerDOM> Listar();
    }
}
