using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace WebService
{
    public class Conexao
    {
        string sConexao;

        public Conexao()
        {
            sConexao = ConfigurationManager.ConnectionStrings["tcc"].ToString();
        }

        public DataSet ExecutarComandoDataSet(string comando)
        {
            DataSet retorno = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(sConexao);
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            try
            { sqlDataAdapter.Fill(retorno); }
            catch
            { }
            finally
            { sqlConnection.Close(); }

            return retorno;
        }

        public DataTable ExecutarComandoDataTable(string comando)
        {
            DataTable retorno = new DataTable();

            DataSet ds = ExecutarComandoDataSet(comando);

            retorno = TemDados(ds) ? ds.Tables[0] : null;

            return retorno;
        }

        public DataRow ExecutarComandoDataRow(string comando)
        {
            DataRow retorno;

            DataTable dt = ExecutarComandoDataTable(comando);

            retorno = TemDados(dt) ? dt.Rows[0] : null;

            return retorno;
        }

        public bool TemDados(object obj)
        {
            bool retorno = false;

            try
            {
                if (obj is DataSet)
                    retorno = ((DataSet)obj).Tables.Count > 0 ? true : false;
                if (obj is DataTable)
                    retorno = ((DataTable)obj).Rows.Count > 0 ? true : false;
                if (obj is DataRow)
                    retorno = ((DataRow)obj) != null ? true : false;
            }
            catch { }

            return retorno;
        }
    }
}