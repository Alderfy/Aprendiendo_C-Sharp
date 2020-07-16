using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Nomina_sParcial
{
    public class EmpleadoRepositorio : iEmpleadoRepositorio
    {
        string connString = ConfigurationManager.ConnectionStrings["sparcial"].ConnectionString;

        public OperationResult Nomina()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Nomina";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    conn.Open();

                    try
                    {
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            return new OperationResult(true, dt);
                        }
                        return new OperationResult() { Result = false, Message = "No se encontraron empleados registrados." };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                    }
                }
            }
        }
    }
}
