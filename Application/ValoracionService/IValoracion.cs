using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ValoracionService.Dominio;
using ValoracionService.Errores;

namespace ValoracionService
{
    [ServiceContract]
    public interface IValoracion
    {

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Valoracion", ResponseFormat = WebMessageFormat.Json)]
        ValoracionDOM Crear(ValoracionDOM Parametro);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Valoracion/{IdValoracion}", ResponseFormat = WebMessageFormat.Json)]
        ValoracionDOM Obtener(string IdValoracion);
        
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
