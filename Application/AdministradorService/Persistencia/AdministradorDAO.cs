using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AdministradorService.Dominio;

namespace AdministradorService.Persistencia
{
    public class AdministradorDAO
    {

        public AdministradorDOM Crear(Dominio.AdministradorDOM Entidad)
        { 
            string sql = @"INSERT INTO dbo.Administrador VALUES (
                                                            @Nombre, 
                                                            @Apellidos, 
                                                            @NumDocumento, 
                                                            @Direccion, 
                                                            @Celular, 
                                                            @Contrasenia,  1);";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdAdministrador", Entidad.IdAdministrador));
                    comando.Parameters.Add(new SqlParameter("@Nombre", Entidad.Nombre));
                    comando.Parameters.Add(new SqlParameter("@Apellidos", Entidad.Apellidos));
                    comando.Parameters.Add(new SqlParameter("@NumDocumento", Entidad.NumDocumento));
                    comando.Parameters.Add(new SqlParameter("@Direccion", Entidad.Direccion));
                    comando.Parameters.Add(new SqlParameter("@Celular", Entidad.Celular));
                    comando.Parameters.Add(new SqlParameter("@Contrasenia", Entidad.Contrasenia)); 
                    comando.ExecuteNonQuery();
                }
            } 
            return Entidad;
        }
        public AdministradorDOM Obtener(string NumDocumento)
        {
            Dominio.AdministradorDOM Encontrado = null;
            try
            {
                string sql = "SELECT * FROM dbo.Administrador WHERE NumDocumento= @NumDocumento";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@NumDocumento", NumDocumento));
                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.Read())
                            {
                                Encontrado = new Dominio.AdministradorDOM()
                                { 
                                    IdAdministrador = (int)resultado["IdAdministrador"],
                                    Apellidos = (string)resultado["Apellidos"],
                                    Direccion = (string)resultado["Direccion"],
                                    Celular = (string)resultado["Celular"],
                                    Nombre = (string)resultado["Nombre"],
                                    Contrasenia = (string)resultado["Contrasenia"],
                                    NumDocumento = (string)resultado["NumDocumento"], 
                                };
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                var ms = ex.Message;
            }
            return Encontrado;
        }
         
        public AdministradorDOM Modificar(Dominio.AdministradorDOM Entidad)
        {
            Dominio.AdministradorDOM Modificado = null;
            try
            {
                string sql = @"UPDATE dbo.Administrador SET Nombre=@Nombre , Apellidos=@Apellidos, NumDocumento = @NumDocumento, Direccion=@Direccion, 
                                Celular = @Celular WHERE IdAdministrador=@IdAdministrador";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@IdAdministrador", Entidad.IdAdministrador));
                        comando.Parameters.Add(new SqlParameter("@Nombre", Entidad.Nombre));
                        comando.Parameters.Add(new SqlParameter("@Apellidos", Entidad.Apellidos));
                        comando.Parameters.Add(new SqlParameter("@NumDocumento", Entidad.NumDocumento));
                        comando.Parameters.Add(new SqlParameter("@Direccion", Entidad.Direccion));
                        comando.Parameters.Add(new SqlParameter("@Celular", Entidad.Celular));
                        comando.Parameters.Add(new SqlParameter("@Contrasenia", Entidad.Contrasenia));
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

        public void Eliminar(string IdUsuario)
        {
            string sql = "UPDATE dbo.Administrador SET FlgActivo=@FlgActivo WHERE IdAdministrador=@IdAdministrador";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdAdministrador", System.Data.SqlDbType.Int, 0, IdUsuario)); 
                    comando.Parameters.Add(new SqlParameter("@FlgActivo", 0));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Dominio.AdministradorDOM> Listar()
        {
            List<Dominio.AdministradorDOM> Encontrados = new List<Dominio.AdministradorDOM>(); 
            string sql = "SELECT * FROM dbo.Administrador where FlgActivo = 1";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        { 
                            Encontrados.Add(new Dominio.AdministradorDOM()
                            {
                                IdAdministrador = (int)resultado["IdAdministrador"],
                                Apellidos = (string)resultado["Apellidos"],
                                Direccion = (string)resultado["Direccion"],
                                Celular = (string)resultado["Celular"],
                                Nombre = (string)resultado["Nombre"],
                                Contrasenia = (string)resultado["Contrasenia"],
                                NumDocumento = (string)resultado["NumDocumento"],
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }
    }
}