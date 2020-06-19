using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Nomina_pParcial
{
    public class empleadoRepositorio : iempleadosRepositorio
    {
        string connString = ConfigurationManager.ConnectionStrings["mssql2"].ConnectionString;

        public OperationResult createEmpleado(Empleado empleado)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "createEmpleado";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@Cedula", empleado.Cedula);
                    cmd.Parameters.AddWithValue("@sueldoBruto", empleado.sueldoBruto);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        tran.Commit();
                        return new OperationResult(true, "Empleado creado satisfactoriamente!");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                    }
                }
            }
        }

        public OperationResult findByCedula(string cedula)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "findByCedula";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cedula", $"{cedula}");
                    cmd.Connection = conn;

                    DataTable dt = new DataTable();

                    conn.Open();

                    try
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        if (dt.Rows.Count > 0)
                        {
                            return new OperationResult(true, dt);
                        }
                        return new OperationResult() { Result = false, Message = $"No existe Suplidor con RNC {cedula}." };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                    }
                }
            }
        }

        public OperationResult updateEmpleado(Empleado empleado, string cedula)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "updateEmpleado";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    cmd.Parameters.AddWithValue("@Cedula", $"{empleado.Cedula}");
                    cmd.Parameters.AddWithValue("@sueldoBruto", $"{empleado.sueldoBruto}");

                    try
                    {
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            return new OperationResult(false, $"No se encontró empleado con RNC {cedula}.");
                        }
                        tran.Commit();
                        return new OperationResult() { Result = true, Message = "Empleado actualizado con éxito" };
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                    }
                }
            }
        }

        public OperationResult softDelete(string cadula)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SoftDelete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    cmd.Parameters.AddWithValue("@Cedula", $"{cadula}");

                    try
                    {
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            return new OperationResult(false, $"No se encontró empleado con cedula {cadula}.");
                        }
                        tran.Commit();
                        return new OperationResult() { Result = true, Message = "Empleado Eliminado Satisfactoriamente" };
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                    }
                }
            }
        }
    }
}