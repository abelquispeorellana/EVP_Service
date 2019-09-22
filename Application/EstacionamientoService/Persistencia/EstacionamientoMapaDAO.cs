using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EstacionamientoService.Dominio;

namespace EstacionamientoService.Persistencia
{
    public class EstacionamientoMapaDAO
    {
        public List<EstacionamientoMapaDOM> Obtener(string IdEstacionamiento)
        {
            List<EstacionamientoMapaDOM> Encontrados = new List<EstacionamientoMapaDOM>();
            string sql = "SELECT * FROM dbo.EstacionamientoMapa where IdEstacionamiento = @IdEstacionamiento";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdEstacionamiento", IdEstacionamiento));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            Encontrados.Add(new EstacionamientoMapaDOM()
                            {
                                IdEstacionamiento = (int)resultado["IdEstacionamiento"], 
                                v = (string)resultado["v"],
                                v1 = (string)resultado["v1"], 
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }
        
    }
}