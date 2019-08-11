using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UsuarioService.Dominio;
using UsuarioService.Errores;
using UsuarioService.Persistencia;

namespace UsuarioService
{
    public class Usuario : IUsuario
    { 

        public UsuarioDOM Crear(UsuarioDOM Parametro)
        {
            var DAO = new UsuarioDAO();
            if (DAO.Obtener(Parametro.NumDocumento) != null) // Ya existe
            {
                throw new WebFaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "101",
                            Descripcion = "El Número documento ya existe"
                        },
                        System.Net.HttpStatusCode.Conflict
                    );
            }
            return DAO.Crear(Parametro);
        }

        public string Eliminar(string IdUsuario)
        {
            try
            {
                var DAO = new UsuarioDAO();
                DAO.Eliminar(IdUsuario);
                return "exitoso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<UsuarioDOM> Listar()
        {
            var DAO = new UsuarioDAO();
            return DAO.Listar();
        }

        public UsuarioDOM Modificar(UsuarioDOM Parametro)
        {
            var DAO = new UsuarioDAO();
            return DAO.Modificar(Parametro);
        }

        public UsuarioDOM Obtener(string NumDocumento)
        {
            var DAO = new UsuarioDAO();
            return DAO.Obtener(NumDocumento);
        }


        public UsuarioDOM UsuarioAutenticar(string NumDocumento, string Contrasenia)
        {
            var DAO = new UsuarioDAO();
            return DAO.UsuarioAutenticar(NumDocumento, Contrasenia);
        }
    }
}
