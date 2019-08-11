using NotificacionService.Errores;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace NotificacionService
{
    [ServiceContract]
    public interface INotificacion
    {

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "EnviarCorreo/{correo}", ResponseFormat = WebMessageFormat.Json)]
        string EnviarCorreo(string correo);
         
    }
}
