using System.Collections.Generic;
using System.Data.SqlClient;
using Lib_Utilitarios;
using Lib_Entidad;
using System.Data;
using System;
namespace Lib_Data
{
    public class DA_Seguridad
    {
        public tb_trabajador Loguear(tb_usuario bean)
        {
            tb_trabajador obj = null;
            SqlConnection con = new SqlConnection();
            Conexion cn = new Conexion();
            con = cn.getConexion();
            con.Open();
            if (con != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Obtener_DatosLogueado";
                cmd.Parameters.AddWithValue("@login", bean.login);
                cmd.Parameters.AddWithValue("@password", bean.password);

                SqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    if (dr.HasRows)
                    {
                        tb_usuario usu = null;
                        if(dr.Read())
                        {
                            usu = new tb_usuario();
                            obj = new tb_trabajador();
                            obj.idTrabajador = dr.GetString(0);
                            obj.nombres = dr.GetString(1);
                            usu.idUsuario = dr.GetInt32(2);
                            obj.estado = dr.GetInt32(3);
                            obj.tb_usuario = usu;
                        }
                        obj.tb_usuario.tb_menu = ObtenerEnlaces(obj.tb_usuario.idUsuario);
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

            return obj;
        }

        public List<tb_menu> ObtenerEnlaces(int idUsuario)
        {
            List<tb_menu> list_menu = new List<tb_menu>();
            tb_menu obj = null;
            SqlConnection con = new SqlConnection();
            Conexion cn = new Conexion();
            con = cn.getConexion();
            con.Open();
            if (con != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Obtener_Enlace";
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new tb_menu();
                            obj.idMenu = dr.GetInt32(0);
                            obj.descripcion_menu = dr.GetString(1);
                            obj.icon_left = dr.GetString(2);
                            obj.icon_right = dr.GetString(3);
                            list_menu.Add(obj);
                        }
                    }
                    for (int x = 0; x < list_menu.Count; x++)
                    {
                        list_menu[x].tb_submenu = ObtenerSubEnlaces(list_menu[x].idMenu);
                    }
                }catch(Exception ex){
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return list_menu;
        }

        public List<tb_submenu> ObtenerSubEnlaces(int idMenu)
        {
            List<tb_submenu> list_submenu = new List<tb_submenu>();
            tb_submenu obj = null;
            SqlConnection con = new SqlConnection();
            Conexion cn = new Conexion();
            con = cn.getConexion();
            con.Open();
            if (con != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Obtener_SubEnlace";
                cmd.Parameters.AddWithValue("@idMenu", idMenu);

                SqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new tb_submenu();
                            obj.idSub_Menu = dr.GetInt32(0);
                            obj.descripcion_sub_menu = dr.GetString(1);
                            obj.url = dr.GetString(2);
                            list_submenu.Add(obj);
                        }
                    }
                }catch(Exception ex){
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return list_submenu;
        }
    }
}
