using System;
using Lib_Entidad;
using Lib_Utilitarios;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

namespace Lib_Data
{
    public class DA_tb_trabajador
    {
        public string UpdateTrabajador(tb_trabajador bean, int evaluar)
        {
            string salida = "1";
            SqlConnection con = new SqlConnection();
            Conexion cn = new Conexion();
            con = cn.getConexion();
            con.Open();
            using (SqlTransaction str = con.BeginTransaction(IsolationLevel.Serializable))
            {
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = str;

                    if (evaluar == 1)
                        cmd.CommandText = "usp_RegistrarTrabajador";
                    else if (evaluar == 2)
                    {
                        cmd.CommandText = "usp_ActualizarTrabajador";
                        cmd.Parameters.AddWithValue("@idTrabajador", bean.idTrabajador);
                        cmd.Parameters.AddWithValue("@idUsuario", bean.tb_usuario.idUsuario);
                    }
                    else if (evaluar == 3)
                        cmd.CommandText = "usp_DarBajaTrabajador";

                    if (evaluar == 1 || evaluar == 2)
                    {
                        cmd.Parameters.AddWithValue("@nombres", bean.nombres);
                        cmd.Parameters.AddWithValue("@ape_paterno", bean.ape_paterno);
                        cmd.Parameters.AddWithValue("@ape_materno", bean.ape_materno);
                        cmd.Parameters.AddWithValue("@dni", bean.dni);
                        cmd.Parameters.AddWithValue("@direccion", bean.direccion);
                        cmd.Parameters.AddWithValue("@correo", bean.correo);
                        cmd.Parameters.AddWithValue("@telefono", bean.telefono);
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", bean.fecha_nacimiento);

                    }

                    if (evaluar == 1)
                    {
                        cmd.Parameters.Add(new SqlParameter("@idTrabajador", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output;
                    }
                    try
                    {
                        cmd.ExecuteNonQuery();
                        str.Commit();
                        if (evaluar == 1)
                        {
                            salida = cmd.Parameters[8].Value.ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        salida = "";
                        str.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
            return salida;
        }

        public tb_trabajador BuscarTrabajador(string idUsuario)
        {
            tb_trabajador bean = null;
            SqlConnection con = new SqlConnection();
            Conexion cn = new Conexion();
            con = cn.getConexion();
            con.Open();

            if (con != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BuscarTrabajador";
                SqlDataReader dr = cmd.ExecuteReader();
                try
                {

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            bean = new tb_trabajador();
                            bean.idTrabajador = dr.GetString(0);
                            bean.nombres = dr.GetString(1);
                            bean.ape_paterno = dr.GetString(2);
                            bean.ape_materno = dr.GetString(3);
                            bean.dni = dr.GetString(4);
                            bean.direccion = dr.GetString(5);
                            bean.correo = dr.GetString(6);
                            bean.telefono = dr.GetString(7);
                            bean.fecha_nacimiento = dr.GetDateTime(8);
                            bean.tb_usuario.idUsuario = dr.GetInt32(10);
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return bean;
        }

        public List<tb_trabajador> ListarTrabajador(tb_trabajador bean)
        {
            tb_trabajador obj = null;
            List<tb_trabajador> data = new List<tb_trabajador>();
            SqlConnection con = new SqlConnection();
            Conexion cn = new Conexion();
            con = cn.getConexion();
            con.Open();

            if (con != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Cons_DatosTrabajador";

                cmd.Parameters.AddWithValue("@idTrabajador", bean.idTrabajador);
                cmd.Parameters.AddWithValue("@trabajador", bean.nombres);
                cmd.Parameters.AddWithValue("@dni", bean.dni);
                cmd.Parameters.AddWithValue("@limit", bean.paginador.limit);
                cmd.Parameters.AddWithValue("@desde", bean.paginador.offset);

                SqlDataReader dr = cmd.ExecuteReader();

                try
                {

                    if (dr.HasRows)
                    {
                        tb_usuario usu = null;
                        while (dr.Read())
                        {
                            usu = new tb_usuario();
                            obj = new tb_trabajador();
                            obj.idTrabajador = dr.GetString(0);
                            obj.nombres = dr.GetString(1);
                            obj.dni = dr.GetString(2);
                            usu.login = dr.GetString(3);
                            usu.password = dr.GetString(4);
                            obj.tb_usuario = usu;
                            obj.telefono = dr.GetString(5);
                            data.Add(obj);
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return data;
        }

        public int TotalRegistroTrabajador(tb_trabajador bean)
        {
            int TotalRegistro = 0;
            SqlConnection con = new SqlConnection();
            Conexion cn = new Conexion();
            con = cn.getConexion();
            con.Open();

            if (con != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TotaRegist_Trabajador";

                cmd.Parameters.AddWithValue("@idTrabajador", bean.idTrabajador);
                cmd.Parameters.AddWithValue("@trabajador", bean.nombres);
                cmd.Parameters.AddWithValue("@dni", bean.dni);
                cmd.Parameters.Add(new SqlParameter("@TOTALREGISTRO", SqlDbType.Int)).Direction = ParameterDirection.Output;
                try
                {
                    cmd.ExecuteNonQuery();
                    TotalRegistro = int.Parse(cmd.Parameters[3].Value.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return TotalRegistro;
        }
    }
}
