using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoAbstractFactory.DTO
{
    public class ClienteDTOX
    {
        private string Imagen;
        private string URLUsuario;
        private string Usuario;
        private string Nombre_Usuario;
        private string URL;
        private string Tiempo_publicacion;
        private string Descripcion;
        private string Hashtag;

        public string Imagen1 { get => Imagen; set => Imagen = value; }
        public string URLUsuario1 { get => URLUsuario; set => URLUsuario = value; }
        public string Usuario1 { get => Usuario; set => Usuario = value; }
        public string Nombre_Usuario1 { get => Nombre_Usuario; set => Nombre_Usuario = value; }
        public string URL1 { get => URL; set => URL = value; }
        public string Tiempo_publicacion1 { get => Tiempo_publicacion; set => Tiempo_publicacion = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public string Hashtag1 { get => Hashtag; set => Hashtag = value; }
    }
}