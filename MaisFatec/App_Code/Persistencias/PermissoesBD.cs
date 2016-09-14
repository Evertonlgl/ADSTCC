using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PermissoesBD
/// </summary>
public class PermissoesBD
{
    public int Update(Permissoes permissoes)
    {
        int erro = 0;

        try
        {
            IDbConnection objConection;
            IDbCommand objComando;
            string sql = "update tbl_permissoes set perm_colunista = ?perm_colunista, perm_moderador = ?perm_moderador, perm_forumPost = ?perm_forumPost, perm_forumResp = ?perm_forumResp, perm_colunaResp = ?perm_colunaResp, perm_data = ?perm_data, perm_motivo = ?perm_motivo, perm_tempo = ?perm_tempo, perm_administrador = ?perm_administrador where usu_id = ?usu_id";
            objConection = Mapped.Connection();
            objComando = Mapped.Command(sql, objConection);

            objComando.Parameters.Add(Mapped.Parameter("?perm_colunista", permissoes.PermissaoColunista));
            objComando.Parameters.Add(Mapped.Parameter("?perm_moderador", permissoes.ModeradorForum));
            objComando.Parameters.Add(Mapped.Parameter("?perm_forumPost", permissoes.ForumPostagem));
            objComando.Parameters.Add(Mapped.Parameter("?perm_forumResp", permissoes.ForumResponder));
            objComando.Parameters.Add(Mapped.Parameter("?perm_colunaResp", permissoes.ColunaResponder));
            objComando.Parameters.Add(Mapped.Parameter("?perm_data", permissoes.DataPermissao));
            objComando.Parameters.Add(Mapped.Parameter("?perm_motivo", permissoes.MotivoPermissao));
            objComando.Parameters.Add(Mapped.Parameter("?perm_tempo", permissoes.TempoPermissao));
            objComando.Parameters.Add(Mapped.Parameter("?perm_administrador", permissoes.AdministradorPermissao));

            objComando.ExecuteNonQuery();
            objConection.Close();
            objConection.Dispose();
            objComando.Dispose();


        }

        catch (Exception e)
        {
            erro = -2;
        }

        return erro;
    }

    public static int UpdateForum(Usuario usr, int per)
    {
        int erro = 0;

        try
        {
            if (per == 1)
            {
                IDbConnection objConection;
                IDbCommand objComando;
                string sql = "update tbl_permissoes set  perm_forumPost = ?perm_forumPost, perm_data=?perm_data, perm_motivo = ?perm_motivo, perm_tempo = ?perm_tempo where usu_id = ?id";
                objConection = Mapped.Connection();
                objComando = Mapped.Command(sql, objConection);


                objComando.Parameters.Add(Mapped.Parameter("?perm_forumPost", usr.Permissoes.ForumPostagem));
                objComando.Parameters.Add(Mapped.Parameter("?perm_data", usr.Permissoes.DataPermissao));
                objComando.Parameters.Add(Mapped.Parameter("?perm_motivo", usr.Permissoes.MotivoPermissao));
                objComando.Parameters.Add(Mapped.Parameter("?perm_tempo", usr.Permissoes.TempoPermissao));
                objComando.Parameters.Add(Mapped.Parameter("?id", usr.IdUsuario));

                objComando.ExecuteNonQuery();
                objConection.Close();
                objConection.Dispose();
                objComando.Dispose();
            }


        }

        catch (Exception e)
        {
            erro = -2;
        }

        return erro;
    }

    public static int VertificaPermissão(Usuario usr)
    {
        int erro = 0;

        try
        {

            IDbConnection objConection;
            IDbCommand objComando;
            string sql = "update tbl_permissoes set  perm_forumPost = 1, perm_motivo = '',  where usu_id = ?id and ";
            sql += " (select count(1) from tbl_permissoes p ";
            sql += " where now() > (date_add(p.perm_data, interval 3 day))  and usu_id=?id)=1;";
            objConection = Mapped.Connection();
            objComando = Mapped.Command(sql, objConection);

            objComando.Parameters.Add(Mapped.Parameter("?id", usr.IdUsuario));

            objComando.ExecuteNonQuery();
            objConection.Close();
            objConection.Dispose();
            objComando.Dispose();

        }


        catch (Exception e)
        {
            erro = -2;
        }

        return erro;
    }

    public void Insert(Usuario usr)
    {
            IDbCommand objComando;
            IDbConnection objConexao;
            string sql = "insert into tbl_permissoes (usu_id, perm_colunista, perm_moderador, perm_forumPost, perm_forumResp, perm_colunaResp, perm_administrador) values (?usu_id, ?perm_colunista, ?perm_moderador, ?perm_forumPost, ?perm_forumResp, ?perm_colunaResp, ?perm_administrador)";
            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?perm_colunista", usr.Permissoes.PermissaoColunista));
            objComando.Parameters.Add(Mapped.Parameter("?perm_moderador", usr.Permissoes.ModeradorForum));
            objComando.Parameters.Add(Mapped.Parameter("?perm_forumPost", usr.Permissoes.ForumPostagem));
            objComando.Parameters.Add(Mapped.Parameter("?perm_forumResp", usr.Permissoes.ForumResponder));
            objComando.Parameters.Add(Mapped.Parameter("?perm_colunaResp", usr.Permissoes.ColunaResponder));
            objComando.Parameters.Add(Mapped.Parameter("?perm_administrador", usr.Permissoes.AdministradorPermissao));
            objComando.Parameters.Add(Mapped.Parameter("?usu_id", usr.IdUsuario));

            objComando.ExecuteNonQuery();
            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();
    }

    public Permissoes Select(int usu_id)
    {

        IDbConnection objConexao;
        IDbCommand objComando;
        IDataReader objReader;
        Permissoes permissoes = null;

        string sql = "select perm_id, usu_id, perm_colunista, perm_moderador, perm_forumPost, perm_forumResp, perm_colunaResp, perm_data, perm_motivo, perm_tempo, perm_administrador from tbl_permissoes where usu_id =?usu_id";

        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);

        objComando.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));
        objReader = objComando.ExecuteReader();
        while (objReader.Read())
        {
            permissoes = new Permissoes();
            permissoes.IdPermissao = Convert.ToInt32(objReader["perm_id"]);
            permissoes.PermissaoColunista = Convert.ToBoolean(objReader["perm_colunista"]);
            permissoes.ModeradorForum = Convert.ToBoolean(objReader["perm_moderador"]);
            permissoes.ForumPostagem = Convert.ToBoolean(objReader["perm_forumPost"]);
            permissoes.ForumResponder = Convert.ToBoolean(objReader["perm_forumResp"]);
            permissoes.ColunaResponder = Convert.ToBoolean(objReader["perm_colunaResp"]);
            permissoes.AdministradorPermissao = Convert.ToBoolean(objReader["perm_administrador"]);
            try
            {
                permissoes.DataPermissao = Convert.ToDateTime(objReader["perm_data"]);
            }
            catch (Exception)
            {

            }

            permissoes.MotivoPermissao = Convert.ToString(objReader["perm_motivo"]);
            try
            {
                permissoes.TempoPermissao = Convert.ToInt32(objReader["perm_tempo"]);
            }
            catch (Exception)
            {

            }

        }

        return permissoes;
    }

}