using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Interesses
{
    private int _idInteresse;
    private string _interessesDescricao;
    private string _interessesTipo;
    private int _indexInteresse;

    public Interesses()
    {
        _interessesDescricao = string.Empty;
        _interessesTipo = string.Empty;
    }

    public int IdInteresse
    {
        get { return _idInteresse; }
        set { _idInteresse = value; }
    }
    public string InteressesDescricao
    {
        get { return _interessesDescricao; }
        set { _interessesDescricao = value; }
    }
    public string InteressesTipo
    {
        get { return _interessesTipo; }
        set { _interessesTipo = value; }
    }
    public int IndexInteresse
    {
        get { return _indexInteresse; }
        set { _indexInteresse = value; }
    }

}//class