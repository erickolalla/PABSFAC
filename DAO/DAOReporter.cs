using ProyectoAbstractFactory.DAO;
using ProyectoAbstractFactory.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
//using System.Web.UI.WebControls;

namespace ProyectoAbstractFactory.DAO
{
    public class DAOReporter : ConexionBDTikTokX
    {
        SqlDataReader LeerFilas;
        //SqlCommand: clase que ejecuta comandos SQL o prodecimientos
        SqlCommand Comando = new SqlCommand();
        public List<DTOReporter> VerHashtagsTX()
        {
            //string conexionX = System.Configuration.ConfigurationManager.ConnectionStrings["DBX"].ConnectionString;
            //SqlConnection ConexionX = new SqlConnection(conexionX);
            SqlConnection ConexionX = new SqlConnection("Data Source=localhost,14333;Initial Catalog=DataX;User Id=sa;Password=erick@123");
            //Se configura el comando
            Comando.Connection = ConexionX;
            //string conexionT = System.Configuration.ConfigurationManager.ConnectionStrings["DBTikTok"].ConnectionString;
            //SqlConnection ConexionT = new SqlConnection(conexionT);
            SqlConnection ConexionT = new SqlConnection("Data Source=localhost,14333;Initial Catalog=DataTikTok;User Id=sa;Password=erick@123");
            List<DTOReporter> ListaserializableTX = new List<DTOReporter>();

            using (ConexionT)
            using (ConexionX)
            {
                // Definición de sentencia SQL
                string consultaSql = @"SELECT hashtag, COUNT(*) AS cantidad " +
                                     "FROM(SELECT FirstHashtag AS hashtag FROM DataTikTok.dbo.Registros " +
                                     "UNION ALL SELECT Hashtag AS hashtag FROM DataX.dbo.Registros) " +
                                     "AS merged_data GROUP BY hashtag HAVING COUNT(*) > 1 ORDER BY cantidad DESC";

                using (SqlCommand Comando = new SqlCommand(consultaSql))
                {
                    // Asigna la conexión adecuada al comando
                    Comando.Connection = ConexionT;

                    // Abre ambas conexiones
                    ConexionT.Open();
                    ConexionX.Open();

                    // Ejecuta la consulta y obtiene los datos
                    using (SqlDataReader LeerFilas = Comando.ExecuteReader())
                    {
                        // Lee los datos y los agrega a la lista serializada
                        while (LeerFilas.Read())
                        {
                            string hashtag = LeerFilas["hashtag"].ToString();
                            int cantidad = int.Parse(LeerFilas["cantidad"].ToString());

                            DTOReporter data = new DTOReporter
                            {
                                Hashtag1 = hashtag,
                                Cantidad1 = cantidad
                            };

                            ListaserializableTX.Add(data);
                           
                        }
                    }
                }
            }         
            
            // Devuelve la lista con el conteo de hashtags
            return ListaserializableTX;


        }

        public Dictionary<string, int> CantHashtagsTX()
        {
            //string conexionX = System.Configuration.ConfigurationManager.ConnectionStrings["DBX"].ConnectionString;
            //SqlConnection ConexionX = new SqlConnection(conexionX);
            SqlConnection ConexionX = new SqlConnection("Data Source=localhost,14333;Initial Catalog=DataX;User Id=sa;Password=erick@123");

            //string conexionT = System.Configuration.ConfigurationManager.ConnectionStrings["DBTikTok"].ConnectionString;
            //SqlConnection ConexionT = new SqlConnection(conexionT);
            SqlConnection ConexionT = new SqlConnection("Data Source=localhost,14333;Initial Catalog=DataTikTok;User Id=sa;Password=erick@123");
            Dictionary<string, int> hashtags = new Dictionary<string, int>();


            // Procedimiento almacenado para contar hashtags de X
            using (ConexionX)
            {
                Comando.Connection = ConexionX;
                Comando.CommandText = "VerHashtagsX";
                Comando.CommandType = CommandType.StoredProcedure;
                ConexionX.Open();

                using (SqlDataReader reader = Comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string hashtag = reader["hashtag"].ToString();
                        int cantidad = Convert.ToInt32(reader["cantidad"]);
                        hashtags.Add(hashtag, cantidad);
                    }
                }
            }

            // Procedimiento almacenado para contar hashtags de TikTok
            using (ConexionT)
            {
                Comando.Connection = ConexionT;
                Comando.CommandText = "VerHashtags";
                Comando.CommandType = CommandType.StoredProcedure;
                ConexionT.Open();

                using (SqlDataReader reader = Comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string hashtag = reader["Firsthashtag"].ToString();
                        int cantidad = Convert.ToInt32(reader["cantidad"]);

                        if (hashtags.ContainsKey(hashtag))
                        {
                            hashtags[hashtag] += cantidad; // Suma la cantidad al hashtag existente si ya está en el diccionario
                        }
                        else
                        {
                            hashtags.Add(hashtag, cantidad);
                        }
                    }
                }
            }
            return hashtags;
        }        

    }
}