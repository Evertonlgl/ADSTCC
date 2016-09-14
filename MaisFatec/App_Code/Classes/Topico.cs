using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Topico
/// </summary>
/// 
//namespace Classes.Topico
//{
public class Topico
{
    public Topico()
    {

    }
    private int _codigo;
    private string _titulo;
    private int _pcodigo;
    private int _asscodigos;
    private string _conteudo;
    private DateTime _data;
    private string _status;
    private string _anexo;
    private string _spam;
    private string _palavra_chave;
    private int _visualizacao;
    private Usuario _usuario;
    private PerfilC _perfil;
    private String _nome;
    private int _m_resposta;
    public global::PerfilC Perfil
    {
        set { _perfil = value; }
        get { return _perfil; }
    }
    public String Nome
    {
        set { _nome = value; }
        get { return _nome; }
    }

    public int AssuntoCodigo
    {
        set { _asscodigos = value; }
        get { return _asscodigos; }

    }


    public int Codigo
    {
        set { _codigo = value; }
        get { return _codigo; }

    }
    public int MelhorResposta
    {
        set { _m_resposta = value; }
        get { return _m_resposta; }

    }
    public Usuario Usu
    {
        set { _usuario = value; }
        get { return _usuario; }

    }


    public int PessoaCodigo
    {
        set { _pcodigo = value; }
        get { return _pcodigo; }

    }


    public string Titulo
    {
        set { _titulo = value; }
        get { return _titulo; }
    }

    public string Conteudo
    {
        set { _conteudo = value; }
        get { return _conteudo; }
    }
    public DateTime DataTopico
    {
        set { _data = value; }
        get { return _data; }
    }

    public string Status
    {
        set { _status = value; }
        get { return _status; }
    }
    public string Anexo
    {
        set { _anexo = value; }
        get { return _anexo; }
    }

    public string PalavraChave
    {
        set { _palavra_chave = value; }
        get { return _palavra_chave; }
    }

    public int Visualizacao
    {
        set { _visualizacao = value; }
        get { return _visualizacao; }
    }
    public string Spam
    {
        set { _spam = value; }
        get { return _spam; }
    }
}
//}