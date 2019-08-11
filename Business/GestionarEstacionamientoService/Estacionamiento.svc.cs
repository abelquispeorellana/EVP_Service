using EVP.Libreria;
using GestionarEstacionamientoService.Dominio;
using System.Collections.Generic;

namespace GestionarEstacionamientoService
{
    public class Estacionamiento : IEstacionamiento
    {
        public EstacionamientoDOM Crear(EstacionamientoDOM Parametro)
        {
            try
            {
                return (new RestClient<EstacionamientoDOM>().POST(Parametro, "http://sharedcss.com/evp/application/EstacionamientoService/Estacionamiento.svc/Estacionamiento").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        public string Eliminar(string IdEstacimionamiento)
        {
            try
            {
                return (new RestClient<string>().DELETE("http://sharedcss.com/evp/application/EstacionamientoService/Estacionamiento.svc/Estacionamiento/" + IdEstacimionamiento).GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public List<EstacionamientoDOM> Listar()
        {
            try
            {
                return (new RestClient<List<EstacionamientoDOM>>().GET("http://sharedcss.com/evp/application/EstacionamientoService/Estacionamiento.svc/Estacionamiento").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public EstacionamientoDOM Modificar(EstacionamientoDOM Parametro)
        {
            try
            {
                return (new RestClient<EstacionamientoDOM>().PUT(Parametro,"http://sharedcss.com/evp/application/EstacionamientoService/Estacionamiento.svc/Estacionamiento").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public EstacionamientoDOM Obtener(string IdUsuario)
        {
            try
            {
                return (new RestClient<EstacionamientoDOM>().GET("http://sharedcss.com/evp/application/EstacionamientoService/Estacionamiento.svc/Estacionamiento/" + IdUsuario).GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
