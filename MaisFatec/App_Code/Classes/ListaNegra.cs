using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListaNegra
/// </summary>
public class ListaNegra
{
	public ListaNegra()
	{
		
	}

        private string _codigo;

        private string _pcodigo;
        private DateTime _data;
        private string _motivo;
        private string _tempo;

        
        

        public string CodigoPessoa
        {
            set { _pcodigo = value; }
            get { return _pcodigo; }
        }
        public string Codigo
        {
            set { _codigo = value; }
            get { return _codigo; }
        }

        public DateTime Data
        {
            set { _data = value; }
            get { return _data; }
        }
        public string Tempo
        {
            set { _tempo = value; }
            get { return _tempo; }
        }

}