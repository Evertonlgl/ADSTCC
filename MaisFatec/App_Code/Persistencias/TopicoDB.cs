using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for TopicoDB
/// </summary>
public class  TopicoDB 
{
	public TopicoDB()
	{

	}

    public static int NovoTopico(Topico topico)
    {
        int errNumber = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "INSERT INTO tbl_topico (perf_id,top_titulo,top_conteudo,top_palavra_chave,top_data,top_src_anexo) VALUES ";
            sql += "(?codigo,?titulo,?conteudo,?palavra_chave,?data,?anexo)";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?codigo", topico.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?titulo", topico.Titulo));
            objCommand.Parameters.Add(Mapped.Parameter("?conteudo", topico.Conteudo));
            objCommand.Parameters.Add(Mapped.Parameter("?palavra_chave", topico.PalavraChave));
            objCommand.Parameters.Add(Mapped.Parameter("?data", topico.DataTopico));
            objCommand.Parameters.Add(Mapped.Parameter("?anexo", topico.Anexo));
            
            objCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            errNumber = -2;
        }
        return errNumber;
    }

    public int ExcluirTopico(int codigo)
    {
        int errNumber = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "DELETE FROM tbl_post WHERE ";
            sql += "top_id=?codigo";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objCommand.ExecuteNonQuery();

            objCommand.Dispose();

            sql = string.Empty;

            sql = "DELETE FROM tbl_topicos WHERE ";
            sql += "top_id=?codigo";
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));

            objCommand.Dispose();
            objConnection.Close();
            objConnection.Dispose();
        }
        catch (Exception ex)
        {
            errNumber = -2;
        }
        return errNumber;

    }

    public static int ContadorVisualizacao(int codigo)
    {
        int errNumber = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;
              
            string sql = "UPDATE tbl_topico SET ";
            sql += " top_visualizacao=top_visualizacao+1 WHERE ";
            sql += " top_id=?codigo";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));

            objCommand.ExecuteNonQuery();
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
        }
        catch (Exception ex)
        {
            errNumber = -2;
        }
        return errNumber;
    }

    public static int Status(int codigo, string status)
    {
        int errNumber = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "UPDATE tbl_topico SET top_status=?status WHERE top_id=?codigo";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);


            objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?status", status));
            

            objCommand.ExecuteNonQuery();
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
        }
        catch (Exception ex)
        {
            errNumber = -2;
        }
        return errNumber;
    }

    

    public static  Topico VisualizarTopico(string codigo )
    {

        Topico objTopico =null;
        
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataReader objDataReader;

        string sql = "SELECT top_titulo,top_conteudo,date(top_data)as top_data,top_status,top_palavra_chave,top_src_anexo,per.perf_id,per.perf_nome FROM tbl_topico top ";
        sql += "inner join tbl_perfil per on per.perf_id=top.perf_id";
        sql += " WHERE top_id=?codigo ";


        objConnection = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
        

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            
            objTopico = new Topico();
            
          
            objTopico.Titulo = Convert.ToString(objDataReader["top_titulo"]);
            objTopico.Conteudo = Convert.ToString(objDataReader["top_conteudo"]);
            objTopico.DataTopico = Convert.ToDateTime(objDataReader["top_data"]);
            objTopico.Status = Convert.ToString(objDataReader["top_status"]);
            //
            objTopico.PalavraChave = Convert.ToString(objDataReader["top_palavra_chave"]);
            objTopico.Anexo = Convert.ToString(objDataReader["top_src_anexo"]);
            objTopico.Nome = Convert.ToString(objDataReader["perf_nome"]);
            

        }
        objConnection.Close();
        objDataReader.Close();
        objCommand.Dispose();
        objConnection.Dispose();

        return objTopico;
        
    }

    public static DataSet BuscaTopico(string palavra)
    {

        
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objAdapter;

        objConnection = Mapped.Connection();

        string sql = "SELECT top.*,usu.* FROM tbl_topico top " ;
        sql += " inner join tbl_perfil usu on usu.perf_id=top.perf_id ";
        sql += " where top.top_palavra_chave =?palavra ";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?palavra", palavra));
        
        

        objAdapter = Mapped.Adapter(objCommand);

        objAdapter.Fill(ds);

        objConnection.Close();

        objCommand.Dispose();
        objConnection.Dispose();

        return ds;

    }

    public static List<string> PesquisaTopico()
    {

        List<string> lista = new List<string>();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataReader objDataReader;

        objConnection = Mapped.Connection();

        string sql = "SELECT top.* FROM tbl_topico top ";

        objCommand = Mapped.Command(sql, objConnection);


        objDataReader = objCommand.ExecuteReader();
        
        while (objDataReader.Read())
        {
            lista.Add(objDataReader["top_palavra_chave"].ToString());
        }

        objConnection.Close();

        objCommand.Dispose();
        objConnection.Dispose();

        return lista;

    }

    public static DataSet GeralTopico()
    {

        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objAdapter;

        objConnection = Mapped.Connection();

        string sql = "SELECT top.top_titulo, top.top_data as Postagem,top.top_visualizacao as Visualizacoes, top.top_status as Situacao, top_id,(select count(1) from tbl_post p where p.top_id=top.top_id and p.pos_spam<>1) as resposta  FROM tbl_topico top order by top.top_data desc,top.top_status desc limit 5";
        

        objCommand = Mapped.Command(sql, objConnection);

        objAdapter = Mapped.Adapter(objCommand);

        objAdapter.Fill(ds);

        objConnection.Close();

        objCommand.Dispose();
        objConnection.Dispose();

        return ds;

    }

    public static DataSet MeusTopicos(int id)
    {

        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objAdapter;

        objConnection = Mapped.Connection();

        string sql = "SELECT top.top_titulo, top.top_data as Postagem,top.top_visualizacao as Visualizacoes, top.top_status as Situacao , top_id FROM tbl_topico top  ";
        sql+=" where top.perf_id=?id";
        sql += " order by top.top_status ,top.top_data desc limit 10";
        

       

        objCommand = Mapped.Command(sql, objConnection);
       
        objCommand.Parameters.Add(Mapped.Parameter("?id",id.ToString()));

        objAdapter = Mapped.Adapter(objCommand);

        objAdapter.Fill(ds);

        objConnection.Close();

        objCommand.Dispose();
        objConnection.Dispose();

        return ds;

    }

    public static int ExcluirUltimoTopico()
    {
        int errNumber = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "delete from tbl_topico where top_id=top_id order by top_id desc limit 1";
            

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            
            objCommand.ExecuteNonQuery();

            objCommand.Dispose();

            objConnection.Close();
            objConnection.Dispose();
        }
        catch (Exception ex)
        {
            errNumber = -2;
        }
        return errNumber;

    }
    public static Topico MelhorResposta(int codigo)
    {

        Topico objTopico = null;

        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataReader objDataReader;

        string sql = "select count(1) as result from tbl_topico t ";
        sql += "inner join tbl_post p on p.top_id=t.top_id";
        sql += " where p.pos_avaliacao>=5 and t.top_id=?codigo ";


        objConnection = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));


        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {

            objTopico = new Topico();


            objTopico.MelhorResposta = Convert.ToInt32(objDataReader["result"]);
            


        }
        objConnection.Close();
        objDataReader.Close();
        objCommand.Dispose();
        objConnection.Dispose();

        return objTopico;

    }


}