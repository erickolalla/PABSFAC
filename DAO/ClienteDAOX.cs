using ProyectoAbstractFactory.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoAbstractFactory.DAO
{
    public class ClienteDAOX : ConexionBDTikTokX
    {
        
        SqlDataReader LeerFilas;
        //SqlCommand: clase que ejecuta comandos SQL o prodecimientos
        SqlCommand Comando = new SqlCommand();        
        public List<ClienteDTOX> VerRegistrosX() //Método que muestra registros
        {
            //string conexionX = System.Configuration.ConfigurationManager.ConnectionStrings["DBX"].ConnectionString;
            //SqlConnection ConexionX = new SqlConnection(conexionX);
            SqlConnection ConexionX = new SqlConnection("Data Source=localhost,14333;Initial Catalog=DataX;User Id=sa;Password=erick@123");
            //Se configura el comando
            Comando.Connection = ConexionX;
            Comando.CommandText = "VerRegistrosX";
            //Se especifica que el tipo de comando es un SP
            Comando.CommandType = CommandType.StoredProcedure;                       
            //Se abre la conexión
            ConexionX.Open();
            //Se obtienen los datos leyendo filas de tablas
            LeerFilas = Comando.ExecuteReader();
            //Se crea un objeto serializable con los datos consultados
            List<ClienteDTOX> ListaSerializada = new List<ClienteDTOX>();
            //Agregar los registros anteriores al objeto serializable
            while (LeerFilas.Read()) //Mientras haya filas, se agregan estas filas a la "lista genérica".
            {
                ListaSerializada.Add(new ClienteDTOX()
                {                                        
                    //Se debe colocar la posición de la columna de la tabla o consulta, la cual inicia en la posición 0
                    Imagen1 = LeerFilas.GetString(0), 
                    URLUsuario1 = LeerFilas.GetString(1), 
                    Usuario1 = LeerFilas.GetString(2),
                    Nombre_Usuario1 = LeerFilas.GetString(3),
                    URL1 = LeerFilas.GetString(4),
                    Tiempo_publicacion1 = LeerFilas.GetString(5),
                    Descripcion1 = LeerFilas.GetString(6),
                    Hashtag1 = LeerFilas.GetString(7),
                });
            }
            //Cerrar la conexion
            LeerFilas.Close();
            ConexionX.Close();
            //Devolver lista serializada
            return ListaSerializada;
        }        

    }


}