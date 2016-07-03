using System;
using Lib_Entidad;
using Lib_Utilitarios;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

namespace Lib_Data
{
    public class DA_tb_Cliente
    {
        public string UpdateCliente(tb_cliente bean, int evaluar)
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
                        cmd.CommandText = "usp_RegistrarCliente";
                    else if (evaluar == 2)
                    {
                        cmd.CommandText = "usp_ActualizarCliente";
                        cmd.Parameters.AddWithValue("@idCliente", bean.idCliente);
                    }
                    else if (evaluar == 3)
                        cmd.CommandText = "usp_DarBajaCliente";
                    cmd.Parameters.AddWithValue("@idCliente", bean.idCliente);

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
                        cmd.Parameters.Add(new SqlParameter("@idCliente", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output;
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



        public tb_cliente BuscarCliente(string idCliente)
        {
            tb_cliente bean = null;
            SqlConnection con = new SqlConnection();
            Conexion cn = new Conexion();
            con = cn.getConexion();
            con.Open();

            if (con != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BuscarCliente";

                cmd.Parameters.AddWithValue("@idCliente", idCliente);

                SqlDataReader dr = cmd.ExecuteReader();
                try
                {

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            bean = new tb_cliente();
                            bean.idCliente = dr.GetString(0);
                            bean.nombres = dr.GetString(1);
                            bean.nombres = dr.GetString(2);
                            bean.ape_paterno = dr.GetString(3);
                            bean.ape_materno = dr.GetString(4);
                            bean.dni = dr.GetString(5);
                            bean.direccion = dr.GetString(6);
                            bean.correo = dr.GetString(7);
                            bean.telefono = dr.GetString(8);
                            bean.fecha_nacimiento = dr.GetDateTime(9);
                            bean.estado = dr.GetInt32(10);
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





        public List<tb_cliente> ListarCliente(tb_cliente bean)
        {
            tb_cliente obj = null;
            List<tb_cliente> data = new List<tb_cliente>();
            SqlConnection con = new SqlConnection();
            Conexion cn = new Conexion();
            con = cn.getConexion();
            con.Open();

            if (con != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarCliente";

                cmd.Parameters.AddWithValue("@idCliente", bean.idCliente);
                cmd.Parameters.AddWithValue("@nombres", bean.nombres);
                cmd.Parameters.AddWithValue("@dni", bean.dni);
                cmd.Parameters.AddWithValue("@correo", bean.correo);
                cmd.Parameters.AddWithValue("@telefono", bean.telefono);
                SqlDataReader dr = cmd.ExecuteReader();
                try
                {

                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {

                            obj = new tb_cliente();
                            obj.idCliente = dr.GetString(0);
                            obj.nombres = dr.GetString(1);
                            obj.dni = dr.GetString(2);
                            obj.correo = dr.GetString(3);
                            obj.telefono = dr.GetString(4);

                            data.Add(bean);
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

        public int TotalRegistroCliente(tb_cliente bean)
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
                cmd.CommandText = "usp_TotaRegist_Cliente";

                cmd.Parameters.AddWithValue("@idCliente", bean.idCliente);
                cmd.Parameters.AddWithValue("@nombre", bean.nombres);
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
