using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for Post
/// </summary>
public class PostDB
{
    public PostDB()
	{
		
	}

    public static int Avaliacao(Post post)
    {
        int errNumber = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "UPDATE tbl_post SET ";
            sql += "pos_avaliacao = ?aval ";
            sql += "WHERE pos_id = ?id";
            // recebendo a conexão e executando o cmd
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            //atribuindo os prm da string sql
            objCommand.Parameters.Add(Mapped.Parameter("?id", post.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?aval", post.Avaliacao));
            

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
        }// try
        catch (Exception ex)
        {
            errNumber = -2;
        }
        return errNumber;
    }// metodo update
    public int Update(Post post)
    {
        int errNumber = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "UPDATE tbl_post SET ";
            sql += "pos_id = ?id ";
            sql += "WHERE pos_avaliacao = ?avaliacao";
            // recebendo a conexão e executando o cmd
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            //atribuindo os prm da string sql
            objCommand.Parameters.Add(Mapped.Parameter("?id", post.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?avaliacao", post.Avaliacao));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
        }// try
        catch (Exception ex)
        {
            errNumber = -2;
        }
        return errNumber;
    }// metodo update


    public static int PostSpam(Post post)
    {
        int errNumber = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "UPDATE tbl_post SET ";
            sql += "pos_spam = ?spam ";
            sql += "WHERE pos_id = ?id";
            // recebendo a conexão e executando o cmd
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            //atribuindo os prm da string sql
            objCommand.Parameters.Add(Mapped.Parameter("?id", post.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?spam", post.Spam));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
        }// try
        catch (Exception ex)
        {
            errNumber = -2;
        }
        return errNumber;
    }// metodo update

    public static int Insert(Post post)
    {
        int errNumber = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO tbl_post(perf_id,top_id,pos_descricao,pos_data) VALUES ";
            sql += "(?idpessoa, ?idtopico,?conteudo,?data)";
            // recebendo a conexão e executando o cmd

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            //atribuindo os prm da string sql
            objCommand.Parameters.Add(Mapped.Parameter("?idpessoa", post.CodigoPessoa));
            objCommand.Parameters.Add(Mapped.Parameter("?idtopico", post.CodigoTop));
            objCommand.Parameters.Add(Mapped.Parameter("?conteudo", post.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?data", post.DataPost));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
        }// try
        catch (Exception ex)
        {
            errNumber = -2;
        }
        return errNumber;
    }

    public int Delete(int id)
    {
        int errNumber = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "DELETE FROM tbl_post ";
            sql += "WHERE pos_id = ?id";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?id", id));
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
        }
        catch (Exception ex)
        {
            errNumber = -2;
        }
        return errNumber;
    }

    //selecionar tudo
    public static DataSet SelectAll(int top, int limit)
    {
        DataSet ds = new DataSet();//instancia data set
        IDbConnection objConexao;//abrir conexao
        IDbCommand objCommand;// objeto para comando
        IDataAdapter objApapter;//

        objConexao = Mapped.Connection();

        string sql = "SELECT p.pos_id,p.pos_descricao ,p.pos_data,p.pos_avaliacao,t.top_titulo,t.top_conteudo,t.top_data,t.top_status,t.top_src_anexo,t.top_palavra_chave,t.top_visualizacao,u.perf_nome,u.perf_id  FROM tbl_post p ";
        sql+=" inner join tbl_topico t on t.top_id=p.top_id ";
        sql+=" inner join tbl_perfil u on u.perf_id=p.perf_id ";
        sql += " WHERE t.top_id=?top_id  and p.pos_spam=0";
        sql += " ORDER BY  p.pos_avaliacao desc ,p.pos_data desc limit ?limit";

        objCommand = Mapped.Command(sql, objConexao);//passar sql mais objeto de conexao
        objCommand.Parameters.Add(Mapped.Parameter("?top_id",top));
        objCommand.Parameters.Add(Mapped.Parameter("?limit", limit));
        objApapter = Mapped.Adapter(objCommand);

        objApapter.Fill(ds);//Set Data Set

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds;
    }

    public static DataSet SelectCount(int top)
    {
        DataSet ds = new DataSet();//instancia data set
        IDbConnection objConexao;//abrir conexao
        IDbCommand objCommand;// objeto para comando
        IDataAdapter objApapter;//

        objConexao = Mapped.Connection();

        string sql = "SELECT count(*) as total FROM tbl_post p ";
        sql += " inner join tbl_topico t on t.top_id=p.top_id ";
        sql += " inner join tbl_perfil u on u.perf_id=p.perf_id ";
        sql += " WHERE t.top_id=?top_id and p.pos_spam<>1 ";
        

        objCommand = Mapped.Command(sql, objConexao);//passar sql mais objeto de conexao
        objCommand.Parameters.Add(Mapped.Parameter("?top_id", top));
        
        objApapter = Mapped.Adapter(objCommand);

        objApapter.Fill(ds);//Set Data Set

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds;
    }
    public static Post Select(int id)
    {
        Post objPost = null;
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataReader objDataReader;

        objConexao = Mapped.Connection();

        string sql = "SELECT * FROM tbl_post ";
        sql += "WHERE pos_id=?id";
        objCommand = Mapped.Command(sql, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?id", id));//remove sqlinject

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            objPost = new Post();
            objPost.Codigo = Convert.ToInt32(objDataReader["pos_id"]);
            objPost.Descricao = Convert.ToString(objDataReader["pos_descricao"]);

        }
        objConexao.Close();
        objDataReader.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return objPost;

    }

}