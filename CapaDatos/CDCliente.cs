using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDCliente
    {
        Conexion objConexion = new Conexion();
        List<CECliente> listCliente = null;
        CECliente oCliente = null;

        public IEnumerable<CECliente> listarCliente()
        {
            try
            {

                SqlConnection cn = objConexion.conectar();
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_listaClienteTodo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        listCliente = new List<CECliente>();
                        while (dr.Read())
                        {
                            oCliente = new CECliente()
                            {
                                id = dr.IsDBNull(dr.GetOrdinal("id")) ? -1 : dr.GetInt32(dr.GetOrdinal("id")),
                                cliente = dr.IsDBNull(dr.GetOrdinal("cliente")) ? "noData" : dr.GetString(dr.GetOrdinal("cliente")),
                                //numero = dr.IsDBNull(dr.GetOrdinal("numero")) ? Convert.ToDecimal(0) : dr.GetDecimal(dr.GetOrdinal("numero")),
                                numero = dr.IsDBNull(dr.GetOrdinal("numero")) ? "noData" : dr.GetString(dr.GetOrdinal("numero")),
                                activo = dr.IsDBNull(dr.GetOrdinal("activo")) ? -1 : dr.GetInt32(dr.GetOrdinal("activo"))
                            };
                            listCliente.Add(oCliente);
                        }
                    }

                }

                return listCliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CECliente> insCliente(string xml)
        {
            try
            {

                SqlConnection cn = objConexion.conectar();
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_insertarCliente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@xml", xml);
                    listCliente = new List<CECliente>();
                    if (Convert.ToBoolean(cmd.ExecuteNonQuery()))
                    {
                        oCliente = new CECliente()
                        {
                            id = 1,
                            cliente = "x",
                            numero = "s",
                            activo = 0

                        };


                    }
                    else
                    {
                        oCliente = new CECliente()
                        {
                            id = 0,
                            cliente = "x",
                            numero = "s",
                            activo = 0
                        };

                    }
                    listCliente.Add(oCliente);
                    return listCliente;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
