using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UsuarioService.Dominio;

namespace UsuarioService.Persistencia
{
    public class UsuarioDAO
    {

        public UsuarioDOM Crear(UsuarioDOM Entidad)
        { 
            string sql = @"INSERT INTO dbo.Usuario VALUES (
                                                            @Tipo, 
                                                            @Nombre, 
                                                            @Apellidos, 
                                                            @NumDocumento, 
                                                            @Direccion, 
                                                            @Celular, 
                                                            @Contrasenia,1);";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Tipo", Entidad.Tipo));
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
        public UsuarioDOM Obtener(string NumDocumento)
        {
            UsuarioDOM Encontrado = null;
            try
            {
                string sql = "SELECT * FROM dbo.Usuario WHERE NumDocumento= @NumDocumento";
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
                                Encontrado = new UsuarioDOM()
                                {
                                    IdUsuario = (int)resultado["IdUsuario"],
                                    Apellidos = (string)resultado["Apellidos"],
                                    NumDocumento = (string)resultado["NumDocumento"],
                                    Direccion = (string)resultado["Direccion"], 
                                    Nombre = (string)resultado["Nombre"],
                                    Tipo = (string)resultado["Tipo"],
                                    Celular = (string)resultado["Celular"], 
                                    Contrasenia = (string)resultado["Contrasenia"],
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

        public UsuarioDOM UsuarioAutenticar(string NumDocumento, string Contrasenia)
        {
            UsuarioDOM Encontrado = null;
            try
            {
                string sql = "SELECT * FROM dbo.Usuario WHERE NumDocumento= @NumDocumento and Contrasenia = @Contrasenia";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@NumDocumento", NumDocumento));
                        comando.Parameters.Add(new SqlParameter("@Contrasenia", Contrasenia));
                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.Read())
                            {
                                Encontrado = new UsuarioDOM()
                                {
                                    IdUsuario = (int)resultado["IdUsuario"],
                                    Apellidos = (string)resultado["Apellidos"],
                                    NumDocumento = (string)resultado["NumDocumento"],
                                    Direccion = (string)resultado["Direccion"],
                                    Nombre = (string)resultado["Nombre"],
                                    Tipo = (string)resultado["Tipo"],
                                    Celular = (string)resultado["Celular"],
                                    Contrasenia = (string)resultado["Contrasenia"],
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

        public UsuarioDOM Modificar(UsuarioDOM Entidad)
        {
            UsuarioDOM Modificado = null;
            try
            {
                string sql = @"UPDATE dbo.Usuario SET Tipo=@Tipo , Nombre=@Nombre, Apellidos = @Apellidos, NumDocumento=@NumDocumento, 
                                Direccion = @Direccion, Celular=@Celular WHERE IdUsuario=@IdUsuario";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@IdUsuario", Entidad.IdUsuario));
                        comando.Parameters.Add(new SqlParameter("@Tipo", Entidad.Tipo));
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
            string sql = "UPDATE dbo.Usuario SET FlgActivo=@FlgActivo WHERE IdUsuario=@IdUsuario";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int, 0, IdUsuario)); 
                    comando.Parameters.Add(new SqlParameter("@FlgActivo", 0));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<UsuarioDOM> Listar()
        {
            List<UsuarioDOM> Encontrados = new List<UsuarioDOM>(); 
            string sql = "SELECT * FROM dbo.Usuario where FlgActivo = 1";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        { 
                            Encontrados.Add(new UsuarioDOM()
                            {
                                IdUsuario = (int)resultado["IdUsuario"],
                                Apellidos = (string)resultado["Apellidos"],
                                NumDocumento = (string)resultado["NumDocumento"],
                                Direccion = (string)resultado["Direccion"],
                                Nombre = (string)resultado["Nombre"],
                                Tipo = (string)resultado["Tipo"],
                                Celular = (string)resultado["Celular"],
                                Contrasenia = (string)resultado["Contrasenia"],
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }
    }
}