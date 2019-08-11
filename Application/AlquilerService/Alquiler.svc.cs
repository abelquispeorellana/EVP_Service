using System;
using System.Collections.Generic;
using System.ServiceModel.Web;
using AlquilerService.Dominio;
using AlquilerService.Errores;
using AlquilerService.Persistencia;

namespace AlquilerService
{
    public class Alquiler : IAlquiler
    { 

        public AlquilerDOM Crear(AlquilerDOM Parametro)
        {
            var DAO = new AlquilerDAO();
            return DAO.Crear(Parametro);
        }

        public string Eliminar(string IdAlquiler)
        {
            try
            {
                var DAO = new AlquilerDAO();
                DAO.Eliminar(IdAlquiler);
                return "exitoso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<AlquilerDOM> Listar()
        {
            var DAO = new AlquilerDAO();
            return DAO.Listar();
        }

        public AlquilerDOM Modificar(AlquilerDOM Parametro)
        {
            var DAO = new AlquilerDAO();
            return DAO.Modificar(Parametro);
        }

        public AlquilerDOM Obtener(string IdEstacimionamiento)
        {
            var DAO = new AlquilerDAO();
            return DAO.Obtener(IdEstacimionamiento);
        } 
    }
}
