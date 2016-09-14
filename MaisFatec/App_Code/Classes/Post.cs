using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Post
/// </summary>
/// 
//namespace Classes.Topico
//{
    public class Post
    {
        public Post()
        {
            
        }
        private int _codigo;

        private int _tcodigo;

        private int _pcodigo;
        private string _descricao;
        private DateTime _data;
        private int _spam;
        private int _avaliacao;
        

        public int CodigoPessoa
        {
            set { _pcodigo = value; }
            get { return _pcodigo; }
        }

        

        public int CodigoTop
        {
            set { _tcodigo = value; }
            get { return _tcodigo; }
        }
        public int  Codigo
        {
            set { _codigo = value; }
            get { return _codigo; }
        }
        public string Descricao
        {
            set { _descricao = value; }
            get { return _descricao; }
        }
        public DateTime DataPost
        {
            set { _data = value; }
            get { return _data; }
        }

        public int Spam 
        {
            set { _spam = value; }
            get { return _spam; }
        }
        public int Avaliacao
        {
            set { _avaliacao = value; }
            get { return _avaliacao; }
        }
    }
//}