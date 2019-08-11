using NotificacionService.Errores;
using System.ServiceModel.Web;

namespace NotificacionService
{
    public class Notificacion : INotificacion
    { 

        public string EnviarCorreo(string Correo)
        {
            return "enviado";
        }
         
    }
}
