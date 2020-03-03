using System;
using System.Data.SqlClient;

namespace Demo.Database
{
    class Program
    {
        const string CONNECTION_STRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=MyBlogs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Posts", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Post post = new Post();
                    post.PostId = int.Parse(sqlDataReader[0].ToString());
                    post.BlogId = int.Parse(sqlDataReader[1].ToString());
                    post.Title = sqlDataReader[2].ToString();
                    post.Content = sqlDataReader[3].ToString();
                    post.Published = DateTime.Parse(sqlDataReader[4].ToString());
                    //Console.WriteLine(sqlDataReader[0]); // post.PostId = sqlDataReader[0]
                    //Console.WriteLine(sqlDataReader[1]); // post.BlogId = sqlDataReader[1]
                    //Console.WriteLine(sqlDataReader[2]); // ... 
                    //Console.WriteLine(sqlDataReader[3]);
                    //Console.WriteLine(sqlDataReader[4]);
                }
            }

            using (SqlConnection sqlConnection1 = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(
                        "INSERT INTO Posts (PostId, BlogId, Title, Content, Publish)" +
                        "VALUES(4, 1, 'Coucou mon seigneur', 'Je joue dans le seigneur des anneaux', '2020-03-03 15:56:00');",
                        sqlConnection1);
                int alteredRows = sqlCommand.ExecuteNonQuery();
                if (alteredRows > 0)
                {
                    Console.WriteLine("La commande s'est exécuté correctement");
                }
                else
                {
                    Console.WriteLine("Une erreur s'est produite");
                }
            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Published { get; set; }
    }
}
