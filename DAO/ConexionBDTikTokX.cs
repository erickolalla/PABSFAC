using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Mvc;

namespace ProyectoAbstractFactory.DAO
{
    public class ConexionBDTikTokX
    {
        //Contiene la cadena de conexión a SQLServer
        //Se declara la conexión de forma protegida como principio de encapsulamiento
        //Es una super clase que será heredada por todas las demás clases DAO

        static string conexionX = "Data Source=localhost,14333;Initial Catalog=DataX;User Id=sa;Password=erick@123";
        SqlConnection ConexionX = new SqlConnection(conexionX);

        static string conexionT = "Data Source=localhost,14333;Initial Catalog=DataTikTok;User Id=sa;Password=erick@123";
        SqlConnection ConexionT = new SqlConnection(conexionT);
    }
}