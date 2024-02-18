using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoAbstractFactory.DTO
{
    public class ClienteDTOTikTok
    {        
        private string Titulo;
        private string Titulo_URL;
        private string Autor;
        private string Descripcion;
        private string URLFirstHashtag;
        private string FirstHashtag;
        private string URLSecondHashtag;
        private string SecondHashtag;
        private string URLThirdHashtag;
        private string ThirdHashtag;
        private string URLFourthHashtag;
        private string FourthHashtag;

        public string Titulo1 { get => Titulo; set => Titulo = value; }
        public string Titulo_URL1 { get => Titulo_URL; set => Titulo_URL = value; }
        public string Autor1 { get => Autor; set => Autor = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public string URLFirstHashtag1 { get => URLFirstHashtag; set => URLFirstHashtag = value; }
        public string FirstHashtag1 { get => FirstHashtag; set => FirstHashtag = value; }
        public string URLSecondHashtag1 { get => URLSecondHashtag; set => URLSecondHashtag = value; }
        public string SecondHashtag1 { get => SecondHashtag; set => SecondHashtag = value; }
        public string URLThirdHashtag1 { get => URLThirdHashtag; set => URLThirdHashtag = value; }
        public string ThirdHashtag1 { get => ThirdHashtag; set => ThirdHashtag = value; }
        public string URLFourthHashtag1 { get => URLFourthHashtag; set => URLFourthHashtag = value; }
        public string FourthHashtag1 { get => FourthHashtag; set => FourthHashtag = value; }
    }
}