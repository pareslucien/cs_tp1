using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace archives
{
    class Program
    {
        static void Main(string[] args)
        {
            // Définition de la base de données pour la connexion
            string connStr = "Server=127.0.0.1;Database=pl503151;Uid=root;Pwd=;";
            string sql1 = "SELECT CB_Utilisateur,Prenom,Email1,Statut FROM utilisateur";
            string sql2 = "INSERT INTO nature(Nom,Ref_Services) VALUES ('DIETSMANN_TECHNOLOGIES',3)";
            string sql3 = "SELECT * FROM nature";

            // Connexion à la base de données MySQL
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");

                // Ouverture de la connexion
                conn.Open();


                // Requête d'affichage sur la base de données
                MySqlCommand cmd = new MySqlCommand(sql1, conn);

                // Exécution de la requête
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2] + " -- " + rdr[3]);
                }
                rdr.Close();         // Fin de l'exécution

                // Requête d'insertion dans la base de données
                cmd = new MySqlCommand(sql2, conn);

                // Exécution de la requête
                rdr = cmd.ExecuteReader();
                Console.WriteLine("Insertion réussie !");
                rdr.Close();         // Fin de l'exécution

                // Requête d'affichage sur la base de données
                cmd = new MySqlCommand(sql3, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                }
                rdr.Close();         // Fin de l'exécution
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            // Déconnexion de la base de données
            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}