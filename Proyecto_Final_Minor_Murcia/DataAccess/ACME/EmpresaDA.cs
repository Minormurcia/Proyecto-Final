using System.Data;
using Microsoft.Data.SqlClient;
using Models.ACME;


namespace DataAccess.ACME
{
    public class EmpresaDA
    {
        private Conexion conexion = new Conexion();

        public void Insertar(EmpresaEntidad empresaEntidad)
        {
            //obtener una instancia de la conexion

            SqlConnection sqlconn = conexion.Conectar();
            SqlCommand sqlcomm = new SqlCommand();

            try
            {
                sqlconn.Open();
                sqlcomm.Connection = sqlconn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.CommandText = "InsertarEmpresa";
                sqlcomm.Parameters.Add(new SqlParameter("@IDEmpresa", SqlDbType.Int)).Direction = ParameterDirection.Output;
                sqlcomm.Parameters.Add(new SqlParameter("@IDTipoEmpresa", empresaEntidad.IDTipoEmpresa));
                sqlcomm.Parameters.Add(new SqlParameter("@Empresa", empresaEntidad.Empresa));
                sqlcomm.Parameters.Add(new SqlParameter("@Direccion", empresaEntidad.Direccion));
                sqlcomm.Parameters.Add(new SqlParameter("@RUC", empresaEntidad.RUC));
                sqlcomm.Parameters.Add(new SqlParameter("@FechaCreacion", empresaEntidad.FechaCreacion));
                sqlcomm.Parameters.Add(new SqlParameter("Presupuesto", empresaEntidad.Presupuesto));
                sqlcomm.Parameters.Add(new SqlParameter("@Activo", empresaEntidad.Activo));

                sqlcomm.ExecuteNonQuery();
                empresaEntidad.IDEmpresa = (int)sqlcomm.Parameters[sqlcomm.Parameters.IndexOf("@IDEmpresa")].Value;

                sqlconn.Close();
            }
            catch(Exception ex)

            {

                throw new Exception("EmpresaDA.Insertar: " + ex.Message);

            }
            finally
            {
                sqlconn.Dispose();
            }


        }


        public void Modificar (EmpresaEntidad empresaEntidad)
        {

            //obtener una instancia de la conexion

            SqlConnection sqlconn = conexion.Conectar();
            SqlCommand sqlcomm = new SqlCommand();

            try
            {
                sqlconn.Open();
                sqlcomm.Connection = sqlconn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.CommandText = "ModificarEmpresa";
                sqlcomm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.IDEmpresa));
                sqlcomm.Parameters.Add(new SqlParameter("@IDTipoEmpresa", empresaEntidad.IDTipoEmpresa));
                sqlcomm.Parameters.Add(new SqlParameter("@Empresa", empresaEntidad.Empresa));
                sqlcomm.Parameters.Add(new SqlParameter("@Direccion", empresaEntidad.Direccion));
                sqlcomm.Parameters.Add(new SqlParameter("@RUC", empresaEntidad.RUC));
                sqlcomm.Parameters.Add(new SqlParameter("@FechaCreacion", empresaEntidad.FechaCreacion));
                sqlcomm.Parameters.Add(new SqlParameter("Presupuesto", empresaEntidad.Presupuesto));
                sqlcomm.Parameters.Add(new SqlParameter("@Activo", empresaEntidad.Activo));

                if (sqlcomm.ExecuteNonQuery() != 1)
                {
                    throw new Exception("EmpresaDA.Modificar: Problema al actualizar.");
                }    

                sqlconn.Close();
            }
            catch (Exception ex)

            {

                throw new Exception("EmpresaDA.Modificar: " + ex.Message);

            }
            finally
            {
                sqlconn.Dispose();
            }

        }

        public void Anular(EmpresaEntidad empresaEntidad)
        {

            //obtener una instancia de la conexion

            SqlConnection sqlconn = conexion.Conectar();
            SqlCommand sqlcomm = new SqlCommand();

            try
            {
                sqlconn.Open();
                sqlcomm.Connection = sqlconn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.CommandText = "AnularEmpresa";
                sqlcomm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.IDEmpresa));
                sqlcomm.ExecuteNonQuery();
                sqlconn.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("EmpresaDA.Anular: " + ex.Message);

            }
            finally
            {
                sqlconn.Dispose();
            }

        }

        public List<EmpresaEntidad> Listar()
        {
            //obtener una instancia de la conexion
            SqlConnection sqlconn = conexion.Conectar();
            SqlDataReader sqlDataRead;
            SqlCommand sqlComm = new SqlCommand();

            List<EmpresaEntidad>? listaEmpresas = new List<EmpresaEntidad>();
            EmpresaEntidad? empresaEntidad;

            try
            {
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ListarEmpresa";

                sqlDataRead = sqlComm.ExecuteReader();


                while (sqlDataRead.Read())
                {
                    empresaEntidad = new();
                    empresaEntidad.IDEmpresa = (int)sqlDataRead["IDEmpresa"];
                    empresaEntidad.IDTipoEmpresa = (int)sqlDataRead["IDTipoEmpresa"];
                    empresaEntidad.Empresa = sqlDataRead["Empresa"].ToString() ?? string.Empty;
                    empresaEntidad.Direccion = sqlDataRead["Direccion"].ToString() ?? string.Empty;
                    empresaEntidad.RUC = sqlDataRead["RUC"].ToString() ?? string.Empty;
                    if (sqlDataRead["FechaCreacion"] != DBNull.Value)
                    {
                        empresaEntidad.FechaCreacion = (DateTime)sqlDataRead["FechaCreacion"];
                    }
                    if (sqlDataRead["Presupuesto"] != DBNull.Value)
                    {
                        empresaEntidad.Presupuesto = (decimal)sqlDataRead["Presupuesto"];
                    }

                    empresaEntidad.Activo = (bool)sqlDataRead["Activo"];

                    listaEmpresas.Add(empresaEntidad);

                }

                sqlconn.Close();

                return listaEmpresas;

            }
            catch (Exception ex)

            {

                throw new Exception("EmpresaDA.Listar: " + ex.Message);

            }
            finally
            {
                sqlconn.Dispose();
            }

        }

        public EmpresaEntidad BuscarID(int IDEmpresa)
        {
            //obtener una instancia de la conexion
            SqlConnection sqlconn = conexion.Conectar();
            SqlDataReader sqlDataReader;
            SqlCommand sqlComm = new SqlCommand();


            EmpresaEntidad? empresaEntidad = null;

            try
            {
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "BuscarEmpresa";

                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", IDEmpresa));



                sqlDataReader = sqlComm.ExecuteReader();


                while (sqlDataReader.Read())
                {
                    empresaEntidad = new();
                    empresaEntidad.IDEmpresa = (int)sqlDataReader["IDEmpresa"];
                    empresaEntidad.IDTipoEmpresa = (int)sqlDataReader["IDTipoEmpresa"];
                    empresaEntidad.Empresa = sqlDataReader["Empresa"].ToString() ?? string.Empty;
                    empresaEntidad.Direccion = sqlDataReader["Direccion"].ToString() ?? string.Empty;
                    empresaEntidad.RUC = sqlDataReader["RUC"].ToString() ?? string.Empty;
                    if (sqlDataReader["FechaCreacion"] != DBNull.Value)
                    {
                        empresaEntidad.FechaCreacion = (DateTime)sqlDataReader["FechaCreacion"];
                    }
                    if (sqlDataReader["Presupuesto"] != DBNull.Value)
                    {
                        empresaEntidad.Presupuesto = (decimal)sqlDataReader["Presupuesto"];
                    }

                    empresaEntidad.Activo = (bool)sqlDataReader["Activo"];



                }

                sqlconn.Close();


                if (empresaEntidad == null)
                {
                    throw new Exception("EmpresaDA.BuscarID: El ID de Empresa no Existe.");
                }


                return empresaEntidad;

            }
            catch (Exception ex)

            {

                throw new Exception("EmpresaDA.BuscarID: " + ex.Message);

            }
            finally
            {
                sqlconn.Dispose();
            }

        }

    }

}


    

     
