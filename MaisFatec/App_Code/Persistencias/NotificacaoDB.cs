using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NotificacaoDB
/// </summary>
public class NotificacaoDB
{
    public static int Insert(Notificacao not)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            string sql = "Insert into tbl_notificacoes( not_descricao, not_data, pos_id, perf_id) values ( ?not_descricao, ?not_data, ?pos_id, ?perf_id)";
            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?not_descricao", not.Descricao));
            objComando.Parameters.Add(Mapped.Parameter("?not_data", not.Data));
            objComando.Parameters.Add(Mapped.Parameter("?pos_id", not.Postcodigo));
            objComando.Parameters.Add(Mapped.Parameter("?perf_id", not.CodigoPessoa));

            //erro = Convert.ToInt32(objComando.ExecuteScalar());
            objComando.ExecuteNonQuery();
            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

        }
        catch (Exception e)
        {
            erro = -2;
        }
        return erro;
    }

    private static int Update(Usuario usu)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            string sql = "update tbl_notificacoes set uso_login = ?not_descricao, not_data = ?not_data, usu_email = ?usu_email where usu_id=?usu_id";
            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?not_descricao", usu.LoginUsuario));
            objComando.Parameters.Add(Mapped.Parameter("?not_data", usu.SenhaUsuario));
            objComando.Parameters.Add(Mapped.Parameter("?usu_email", usu.EmailUsuario));

            objComando.ExecuteNonQuery();
            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();
        }
        catch (Exception e)
        {
            erro = -2;
        }
        return erro;
    }

    public static DataSet SelectAll(int limit)
    {
        DataSet ds = new DataSet();//instancia data set
        IDbConnection objConexao;//abrir conexao
        IDbCommand objCommand;// objeto para comando
        IDataAdapter objApapter;//

        objConexao = Mapped.Connection();

        string sql = "SELECT p.pos_id,p.pos_descricao ,p.pos_data,p.pos_avaliacao,t.top_titulo,u.perf_nome,u.perf_id,not_id, not_descricao, not_data, not_status, not_visualizado,u2.perf_nome as NomePost,u2.usu_id ";
        sql += " from tbl_notificacoes n";
        sql += " inner join tbl_post p on p.pos_id=n.pos_id ";
        sql += " inner join tbl_topico t on t.top_id=p.top_id ";
        sql += " inner join tbl_perfil u on u.perf_id=n.perf_id ";
        sql += " inner join tbl_perfil u2 on u2.perf_id=p.perf_id ";
        
        sql += " ORDER BY  p.pos_data desc limit 5;";

        objCommand = Mapped.Command(sql, objConexao);//passar sql mais objeto de conexao

        objCommand.Parameters.Add(Mapped.Parameter("?limit", limit));
        objApapter = Mapped.Adapter(objCommand);

        objApapter.Fill(ds);//Set Data Set

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds;
    }
    public static Notificacao Select(int codigo)
    {

        Notificacao objNotificacao = null;

        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataReader objDataReader;

        string sql = "SELECT p.pos_id,p.pos_descricao ,p.pos_data,p.pos_avaliacao,t.top_titulo,u.perf_nome,u.perf_id,not_id, not_descricao, not_data, not_status, not_visualizado,u2.perf_nome as NomePost,u2.usu_id ";
        sql += " from tbl_notificacoes n";
        sql += " inner join tbl_post p on p.pos_id=n.pos_id ";
        sql += " inner join tbl_topico t on t.top_id=p.top_id ";
        sql += " inner join tbl_perfil u on u.perf_id=n.perf_id ";
        sql += " inner join tbl_perfil u2 on u2.perf_id=p.perf_id ";
        sql += " WHERE t.top_id=?codigo ";


        objConnection = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));


        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {

            objNotificacao = new Notificacao();


            objNotificacao.CodigoPessoa= Convert.ToInt32(objDataReader["usu_id"].ToString());
            

        }
        objConnection.Close();
        objDataReader.Close();
        objCommand.Dispose();
        objConnection.Dispose();

        return objNotificacao;

    }
    public static DataSet SelectAbrir(int codigo)
    {

        DataSet ds = new DataSet();

        IDbConnection objConnection;
        IDbCommand objCommand;
        
        IDataAdapter objApapter;

        objConnection = Mapped.Connection();
        string sql = "SELECT p.pos_id,p.pos_descricao ,p.pos_data,p.pos_avaliacao,t.top_titulo,u.perf_nome,u.perf_id,not_id, not_descricao, not_data, not_status, not_visualizado,u2.perf_nome as NomePost,u2.usu_id ";
        sql += " from tbl_notificacoes n";
        sql += " inner join tbl_post p on p.pos_id=n.pos_id ";
        sql += " inner join tbl_topico t on t.top_id=p.top_id ";
        sql += " inner join tbl_perfil u on u.perf_id=n.perf_id ";
        sql += " inner join tbl_perfil u2 on u2.perf_id=p.perf_id ";
        sql += " WHERE p.pos_id=?codigo ";



        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));


        objApapter = Mapped.Adapter(objCommand);

        objApapter.Fill(ds);//Set Data Set

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();

        return ds;

    }
}