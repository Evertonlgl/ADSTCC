using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


public class MiniCvBD
{
    public List<MiniCv> Select(int perf_id)
    {
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataReader objReader;
        MiniCv minicv = null;
        List<MiniCv> lstMinicv = new List<MiniCv>();

        string sql = "select mincv_descricao, mincv_tipo, mincv_instituicao, mincv_dataTermino from tbl_minicv where perf_id = ?perf_id order by mincv_tipo";

        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);

        objComando.Parameters.Add(Mapped.Parameter("?perf_id", perf_id));
        objReader = objComando.ExecuteReader();
        while (objReader.Read())
        {
            minicv = new MiniCv();
            minicv.MiniCvDescricao = Convert.ToString(objReader["mincv_descricao"]);
            minicv.MiniCvTipo = Convert.ToString(objReader["mincv_tipo"]);
            minicv.MiniCvInstituicao = Convert.ToString(objReader["mincv_instituicao"]);
            try
            {
                minicv.MiniCvDataTermino = Convert.ToDateTime(objReader["mincv_dataTermino"]);
            }
            catch (Exception)
            {
            }
            lstMinicv.Add(minicv);
        }
        return lstMinicv;
    }

    public void InsertNovoUsr(List<MiniCv> minicvLst, int idPerfil)
    {
            IDbConnection objConection = null;
            IDbCommand objComando = null;

            foreach (MiniCv element in minicvLst)
	        {
		        string sql = "insert into tbl_minicv(mincv_descricao, mincv_tipo, mincv_instituicao, perf_id, mincv_index) values (?mincv_descricao, ?mincv_tipo, ?mincv_instituicao, ?perf_id, ?mincv_index)";
                objConection = Mapped.Connection();
                objComando = Mapped.Command(sql, objConection);
                objComando.Parameters.Add(Mapped.Parameter("?mincv_descricao", element.MiniCvDescricao));
                objComando.Parameters.Add(Mapped.Parameter("?mincv_tipo", element.MiniCvTipo));
                objComando.Parameters.Add(Mapped.Parameter("?mincv_instituicao", element.MiniCvInstituicao));
                objComando.Parameters.Add(Mapped.Parameter("?perf_id", idPerfil));
                objComando.Parameters.Add(Mapped.Parameter("?mincv_index", element.IndexMiniCv));
                objComando.ExecuteNonQuery(); 
	        }

            objConection.Close();
            objConection.Dispose();
            objComando.Dispose();
    }//insert


}//class