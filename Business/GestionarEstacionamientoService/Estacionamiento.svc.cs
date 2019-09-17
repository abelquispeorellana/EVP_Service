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

        public List<EstacionamientoDOM> Obtener(string PrecioPorHora)
        {
            try
            {
                return (new RestClient<List<EstacionamientoDOM>>().GET("http://sharedcss.com/evp/application/EstacionamientoService/Estacionamiento.svc/Estacionamiento/" + PrecioPorHora).GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public List<EstacionamientoDOM> ObtenerPorUsuario(string IdUsuario)
        {
            try
            {
                return (new RestClient<List<EstacionamientoDOM>>().GET("http://sharedcss.com/evp/application/EstacionamientoService/Estacionamiento.svc/EstacionamientoPorUsuario/" + IdUsuario).GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
