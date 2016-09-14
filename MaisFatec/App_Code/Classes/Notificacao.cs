using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Notificacao
/// </summary>
/// 
//namespace Classes.Topico
//{
public class Notificacao
{
    public Notificacao()
    {

    }
    

    private string _codigo;

    private int _pcodigo;
    private DateTime _data;
    private string _status;
    private string _descricao;
    private int _postCodigo;
    public int Postcodigo
    {
        set { _postCodigo = value; }
        get { return _postCodigo; }
    }

    public string Descricao
    {
        set { _descricao = value; }
        get { return _descricao; }
    }

    public int CodigoPessoa
    {
        set { _pcodigo = value; }
        get { return _pcodigo; }
    }
   

    public DateTime Data
    {
        set { _data = value; }
        get { return _data; }
    }

    public string Status
    {
        set { _status = value; }
        get { return _status; }
    }
}
//}