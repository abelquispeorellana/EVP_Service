using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ValoracionService.Dominio;
using ValoracionService.Errores;
using ValoracionService.Persistencia;

namespace ValoracionService
{
    public class Valoracion : IValoracion
    { 

        public ValoracionDOM Crear(ValoracionDOM Parametro)
        {
            try
            {
                var DAO = new ValoracionDAO();
                //if (DAO.Obtener(Parametro.NumDocumento) != null) // Ya existe
                //{
                //}
                return DAO.Crear(Parametro);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "400",
                            Descripcion = ex.Message
                        },
                        System.Net.HttpStatusCode.Conflict
                    );
            }
        }

        public string Eliminar(string IdValoracion)
        {
            try
            {
                var DAO = new ValoracionDAO();
                DAO.Eliminar(IdValoracion);
                return "exitoso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<ValoracionDOM> Listar()
        {
            var DAO = new ValoracionDAO();
            return DAO.Listar();
        }

        public ValoracionDOM Modificar(ValoracionDOM Parametro)
        {
            var DAO = new ValoracionDAO();
            return DAO.Modificar(Parametro);
        }

        public ValoracionDOM Obtener(string IdValoracion)
        {
            var DAO = new ValoracionDAO();
            return DAO.Obtener(IdValoracion);
        }
         
    }
}
