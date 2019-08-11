using AdministradorService.Dominio;
using AdministradorService.Errores;
using AdministradorService.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AdministradorService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Administrador" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Administrador.svc o Administrador.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Administrador : IAdministrador
    {
        public AdministradorDOM Crear(AdministradorDOM Parametro)
        {
            var DAO = new AdministradorDAO();
            if (DAO.Obtener(Parametro.NumDocumento) != null) // Ya existe
            {
                throw new WebFaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "101",
                            Descripcion = "El NroDocumento ya existe"
                        },
                        System.Net.HttpStatusCode.Conflict
                    );
            }
            return DAO.Crear(Parametro);
        }

        public string Eliminar(string IdAdministrador)
        {
            try
            {
                var DAO = new AdministradorDAO();
                DAO.Eliminar(IdAdministrador);
                return "exitoso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<AdministradorDOM> Listar()
        {
            var DAO = new AdministradorDAO();
            return DAO.Listar();
        }

        public AdministradorDOM Modificar(AdministradorDOM Parametro)
        {
            var DAO = new AdministradorDAO();
            return DAO.Modificar(Parametro);
        }

        public AdministradorDOM Obtener(string NroDocumento)
        {
            var DAO = new AdministradorDAO();
            return DAO.Obtener(NroDocumento);
        }


        public AdministradorDOM Autenticar(string NroDocumento, string Contrasenia)
        {
            var DAO = new AdministradorDAO();
            var instAdministrador = DAO.Obtener(NroDocumento);
            if (instAdministrador == null) {

                throw new WebFaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "101",
                            Descripcion = "NroDocumento no existe"
                        },
                        System.Net.HttpStatusCode.Conflict
                    );
            }
            if (instAdministrador.Contrasenia != Contrasenia)
            {

                throw new WebFaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "101",
                            Descripcion = "Contraseña no es correcta"
                        },
                        System.Net.HttpStatusCode.Conflict
                    );
            }
            return instAdministrador;
        }
    }
}
