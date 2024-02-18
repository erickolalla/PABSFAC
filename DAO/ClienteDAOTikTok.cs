using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ProyectoAbstractFactory.DTO;

namespace ProyectoAbstractFactory.DAO
{
    public class ClienteDAOTikTok : ConexionBDTikTokX
    {
        //SqlDataReader: lee filas de tablas
        SqlDataReader LeerFilas;
        //SqlCommand: clase que ejecuta comandos SQL o prodecimientos
        SqlCommand Comando = new SqlCommand();
        public List<ClienteDTOTikTok> VerRegistrosT() //Método que muestra registros
        {
            //string conexionT = System.Configuration.ConfigurationManager.ConnectionStrings["DBTikTok"].ConnectionString;
            //SqlConnection ConexionT = new SqlConnection(conexionT);
            SqlConnection ConexionT = new SqlConnection("Data Source=localhost,14333;Initial Catalog=DataTikTok;User Id=sa;Password=erick@123");
            List<ClienteDTOTikTok> ListaSerializada = new List<ClienteDTOTikTok>();
            using (ConexionT)
            {
                //Se configura el comando
                Comando.Connection = ConexionT;
                Comando.CommandText = "VerRegistrosT";
                //Se especifica que el tipo de comando es un SP
                Comando.CommandType = CommandType.StoredProcedure;
                //El parámetro debe estar escrito igual que en el SP, y se envía el parámeto Condicion del método
                //Comando.Parameters.AddWithValue("@Condicion", Condicion);
                //Se abre la conexión
                ConexionT.Open();
                //Se obtienen los datos leyendo filas de tablas
                LeerFilas = Comando.ExecuteReader();
                //Se crea un objeto serializable con los datos consultados            
                //Agregar los registros anteriores al objeto serializable
                while (LeerFilas.Read()) //Mientras haya filas, se agregan estas filas a la "lista genérica".
                {
                    ListaSerializada.Add(new ClienteDTOTikTok()
                    {                        
                        //Se debe colocar la posición de la columna de la tabla o consulta, la cual inicia en la posición 0
                        Titulo1 = LeerFilas.GetString(0),
                        Titulo_URL1 = LeerFilas.GetString(1),
                        Autor1 = LeerFilas.GetString(2), 
                        Descripcion1 = LeerFilas.GetString(3),
                        URLFirstHashtag1 = LeerFilas.GetString(4),
                        FirstHashtag1 = LeerFilas.GetString(5),
                        URLSecondHashtag1 = LeerFilas.GetString(6),
                        SecondHashtag1 = LeerFilas.GetString(7),
                        URLThirdHashtag1 = LeerFilas.GetString(8),
                        ThirdHashtag1 = LeerFilas.GetString(9),
                        URLFourthHashtag1 = LeerFilas.GetString(10),
                        FourthHashtag1 = LeerFilas.GetString(11),
                    });
                }
                //Cerrar la conexion
                LeerFilas.Close();
                ConexionT.Close();
                //Devolver lista serializada
                return ListaSerializada;
            }

        }        

    }




}