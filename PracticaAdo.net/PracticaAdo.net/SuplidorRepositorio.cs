using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Practica_Ado.net
{
    public class SuplidorRepositorio : iSuplidoresRepositorio
    {
        string connString = ConfigurationManager.ConnectionStrings["mssql1"].ConnectionString;

        public OperationResult Create(Suplidor suplidor)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "createSuplidor";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    cmd.Parameters.AddWithValue("@Nombre", suplidor.Nombre);
                    cmd.Parameters.AddWithValue("@RNC", suplidor.RNC);
                    cmd.Parameters.AddWithValue("@Direccion", suplidor.Direccion);
                    cmd.Parameters.AddWithValue("@Representante", suplidor.Representante);
                  
                    try
                    {
                        cmd.ExecuteNonQuery();
                        tran.Commit();
                        return new OperationResult(true, "Suplidor creado satisfactoriamente!");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                    }
                }
            }
        }

        public OperationResult GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "GetAll";
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
                            return new OperationResult() { Result = false, Message = "No se encontraron registros." };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                    }
                }
            }
        }

        public OperationResult FindByRNC(string rnc)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "FindByRNC";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RNC", rnc);
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
                        return new OperationResult() { Result = false, Message = $"No existe Suplidor con RNC {rnc}." };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                    }
                }
            }
        }

        public OperationResult Update(Suplidor suplidor, string rnc)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "updateSuplidor";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    cmd.Parameters.AddWithValue("@Direccion", suplidor.Direccion);
                    cmd.Parameters.AddWithValue("@Representante", suplidor.Representante);
                    cmd.Parameters.AddWithValue("@RNC", suplidor.RNC);

                    try
                    {
                        var result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            return new OperationResult(false, $"No se encontró Suplidor con RNC {rnc}.");
                        }
                        tran.Commit();
                        return new OperationResult() { Result = true, Message = "Suplidor actualizado con éxito" };
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                    }
                }
            }
        }

        public OperationResult SoftDelete(string rnc)
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
                    cmd.Parameters.AddWithValue("@RNC", rnc);

                    try
                    {
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            return new OperationResult(false, $"No se encontró Suplidor con RNC {rnc}.");
                        }
                        tran.Commit();
                        return new OperationResult() { Result = true, Message = "Suplidor Eliminado Satisfactoriamente" };
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
