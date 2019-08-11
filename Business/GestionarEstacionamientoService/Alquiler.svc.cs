using EVP.Libreria;
using GestionarEstacionamientoService.Dominio;
using System.Collections.Generic;

namespace GestionarEstacionamientoService
{
    public class Alquiler : IAlquiler
    {
        public AlquilerDOM Crear(AlquilerDOM Parametro)
        {
            try
            {
                return (new RestClient<AlquilerDOM>().POST(Parametro, "http://sharedcss.com/evp/application/AlquilerService/Alquiler.svc/Alquiler").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public string Eliminar(string IdAlquiler)
        {
            try
            {
                return (new RestClient<string>().DELETE("http://sharedcss.com/evp/application/AlquilerService/Alquiler.svc/Alquiler/" + IdAlquiler).GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public List<AlquilerDOM> Listar()
        {
            try
            {
                return (new RestClient<List<AlquilerDOM>>().GET("http://sharedcss.com/evp/application/AlquilerService/Alquiler.svc/Alquiler").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public AlquilerDOM Modificar(AlquilerDOM Parametro)
        {
            try
            {
                return (new RestClient<AlquilerDOM>().PUT(Parametro, "http://sharedcss.com/evp/application/AlquilerService/Alquiler.svc/Alquiler").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public AlquilerDOM Obtener(string IdEstacimionamiento)
        {
            try
            {
                return (new RestClient<AlquilerDOM>().GET("http://sharedcss.com/evp/application/AlquilerService/Alquiler.svc/Alquiler/" + IdEstacimionamiento).GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
