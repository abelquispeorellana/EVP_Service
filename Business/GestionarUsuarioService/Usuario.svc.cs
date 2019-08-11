using EVP.Libreria;
using GestionarUsuarioService.Dominio;
using System.Collections.Generic;

namespace GestionarUsuarioService
{
    public class Usuario : IUsuario
    {
        public UsuarioDOM Crear(UsuarioDOM Parametro)
        {
            try
            {
                return (new RestClient<UsuarioDOM>().POST( Parametro , "http://sharedcss.com/evp/application/UsuarioService/Usuario.svc/Usuario").GetAwaiter().GetResult());

            }
            catch (System.Exception )
            {
                throw;
            }
        }
         
        public string Eliminar(string IdUsuario)
        {
            try
            {
                return (new RestClient<string>().DELETE("http://sharedcss.com/evp/application/UsuarioService/Usuario.svc/Usuario/" + IdUsuario).GetAwaiter().GetResult());

            }
            catch (System.Exception )
            {
                throw;
            }
        }

        public List<UsuarioDOM> Listar()
        {
            try
            {
                return (new RestClient<List<UsuarioDOM>>().GET("http://sharedcss.com/evp/application/UsuarioService/Usuario.svc/Usuario").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public UsuarioDOM Modificar(UsuarioDOM Parametro)
        {
            try
            {
                return (new RestClient<UsuarioDOM>().PUT(Parametro, "http://sharedcss.com/evp/application/UsuarioService/Usuario.svc/Usuario").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public UsuarioDOM Obtener(string NumDocumento)
        {
            return (new RestClient<UsuarioDOM>().GET("http://sharedcss.com/evp/application/UsuarioService/Usuario.svc/Usuario/" + NumDocumento).GetAwaiter().GetResult());
        }

        public string ValidarPIN(string NumDocumento, string PIN)
        {
            return "exitoso";
        }
    }
}
