using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EstacionamientoService.Dominio;

namespace EstacionamientoService.Persistencia
{
    public class EstacionamientoDAO
    {

        public EstacionamientoDOM Crear(EstacionamientoDOM Entidad)
        { 
            string sql = @"INSERT INTO dbo.Estacionamiento VALUES (
                                                            @IdUsuario, 
                                                            @Direccion, 
                                                            @Telefono, 
                                                            @PrecioPorHora, 
                                                            @Dimencion, 
                                                            @ImagenPortada, 
                                                            @ImagenLogo,1);";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", Entidad.IdUsuario));
                    comando.Parameters.Add(new SqlParameter("@Direccion", Entidad.Direccion));
                    comando.Parameters.Add(new SqlParameter("@Telefono", Entidad.Telefono));
                    comando.Parameters.Add(new SqlParameter("@PrecioPorHora", Entidad.PrecioPorHora.ToString()));
                    comando.Parameters.Add(new SqlParameter("@Dimencion", Entidad.Dimencion));
                    comando.Parameters.Add(new SqlParameter("@ImagenPortada", Entidad.ImagenPortada));
                    comando.Parameters.Add(new SqlParameter("@ImagenLogo", Entidad.ImagenLogo));
                    comando.ExecuteNonQuery();
                }
            } 
            return Entidad;
        }

        public List<EstacionamientoDOM> Obtener(string PrecioPorHora)
        {
            List<EstacionamientoDOM> Encontrados = new List<EstacionamientoDOM>();
            string sql = "SELECT * FROM dbo.Estacionamiento where PrecioPorHora like '%" + (PrecioPorHora == "xxx" ? "%" : PrecioPorHora) + "%' and FlgActivo = 1";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    //comando.Parameters.Add(new SqlParameter("@PrecioPorHora", PrecioPorHora));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            Encontrados.Add(new EstacionamientoDOM()
                            {
                                IdEstacionamiento = (int)resultado["IdEstacionamiento"],
                                IdUsuario = (int)resultado["IdUsuario"],
                                Direccion = (string)resultado["Direccion"],
                                Telefono = (string)resultado["Telefono"],
                                Dimencion = (string)resultado["Dimencion"],
                                PrecioPorHora = (string)resultado["PrecioPorHora"],
                                ImagenLogo = (int)resultado["ImagenLogo"],
                                ImagenPortada = (int)resultado["ImagenPortada"],
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }

        public List<EstacionamientoDOM> ObtenerPorUsuario(string IdUsuario)
        {
            List<EstacionamientoDOM> Encontrados = new List<EstacionamientoDOM>();
            string sql = "SELECT * FROM dbo.Estacionamiento where IdUsuario = @IdUsuario and FlgActivo = 1";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", IdUsuario));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            Encontrados.Add(new EstacionamientoDOM()
                            {
                                IdEstacionamiento = (int)resultado["IdEstacionamiento"],
                                IdUsuario = (int)resultado["IdUsuario"],
                                Direccion = (string)resultado["Direccion"],
                                Telefono = (string)resultado["Telefono"],
                                Dimencion = (string)resultado["Dimencion"],
                                PrecioPorHora = (string)resultado["PrecioPorHora"],
                                ImagenLogo = (int)resultado["ImagenLogo"],
                                ImagenPortada = (int)resultado["ImagenPortada"],
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }

        public EstacionamientoDOM Modificar(EstacionamientoDOM Entidad)
        {
            EstacionamientoDOM Modificado = null;
            try
            {
                string sql = @"UPDATE dbo.Estacionamiento SET Direccion=@Direccion , Telefono=@Telefono, PrecioHora = @PrecioHora, Dimencion=@Dimencion WHERE IdEstacionamiento=@IdEstacionamiento";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@IdEstacionamiento", Entidad.IdEstacionamiento)); 
                        comando.Parameters.Add(new SqlParameter("@Direccion", Entidad.Direccion));
                        comando.Parameters.Add(new SqlParameter("@Telefono", Entidad.Telefono));
                        comando.Parameters.Add(new SqlParameter("@PrecioPorHora", Entidad.PrecioPorHora.ToString()));
                        comando.Parameters.Add(new SqlParameter("@Dimencion", Entidad.Dimencion));
                        comando.Parameters.Add(new SqlParameter("@ImagenPortada", Entidad.ImagenPortada));
                        comando.Parameters.Add(new SqlParameter("@ImagenLogo", Entidad.ImagenLogo));
                        comando.ExecuteNonQuery();
                    }
                }
                Modificado = Entidad;
            }
            catch (System.Exception ex)
            {
                var ms = ex.Message;
            }
            return Modificado;
        }

        public void Eliminar(string IdEstacionamiento)
        {
            string sql = "UPDATE dbo.Estacionamiento SET FlgActivo=@FlgActivo WHERE IdEstacionamiento=@IdEstacionamiento";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdEstacionamiento", System.Data.SqlDbType.Int, 0, IdEstacionamiento)); 
                    comando.Parameters.Add(new SqlParameter("@FlgActivo", 0));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<EstacionamientoDOM> Listar()
        {
            List<EstacionamientoDOM> Encontrados = new List<EstacionamientoDOM>(); 
            string sql = "SELECT * FROM dbo.Estacionamiento where FlgActivo = 1";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        { 
                            Encontrados.Add(new EstacionamientoDOM()
                            {
                                IdEstacionamiento = (int)resultado["IdEstacionamiento"],
                                IdUsuario = (int)resultado["IdUsuario"],
                                Direccion = (string)resultado["Direccion"],
                                Telefono = (string)resultado["Telefono"],
                                Dimencion = (string)resultado["Dimencion"],
                                PrecioPorHora = (string)resultado["PrecioPorHora"],
                                ImagenLogo = (int)resultado["ImagenLogo"],
                                ImagenPortada = (int)resultado["ImagenPortada"],
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }
    }
}