using GestionarAsistenteService.Dominio;
using GestionarAsistenteService.Errores;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace GestionarAsistenteService
{
    [ServiceContract]
    public interface IValoracion
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Valoracion", ResponseFormat = WebMessageFormat.Json)]
        ValoracionDOM Crear(ValoracionDOM Parametro);
         
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Valoracion", ResponseFormat = WebMessageFormat.Json)]
        ValoracionDOM Modificar(ValoracionDOM Parametro);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Valoracion/{IdValoracion}", ResponseFormat = WebMessageFormat.Json)]
        string Eliminar(string IdValoracion);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Valoracion", ResponseFormat = WebMessageFormat.Json)]
        List<ValoracionDOM> Listar();
    }
}

