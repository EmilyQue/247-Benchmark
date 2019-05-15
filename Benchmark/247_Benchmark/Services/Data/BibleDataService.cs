using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using _247_Benchmark.Models;

namespace _247_Benchmark.Services.Data
{
    public class BibleDataService
    {
        // setup database connection string
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;initial catalog=Bible ;Integrated Security=True;";

        //method to add bible verse to database
        public bool addVerse(BibleModel bible)
        {
            try
            {
                // Setup SELECT query with parameters
                string query = "INSERT INTO dbo.Bible (testament, book, chapter, verseNo, verse) VALUES (@testament, @book, @chapter, @verseNo, @verse)";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@testament", SqlDbType.VarChar, 50).Value = bible.testament;
                    cmd.Parameters.Add("@book", SqlDbType.VarChar, 50).Value = bible.bookName;
                    cmd.Parameters.Add("@chapter", SqlDbType.Int, 50).Value = bible.chapterNo;
                    cmd.Parameters.Add("@verseNo", SqlDbType.Int, 50).Value = bible.verseNo;
                    cmd.Parameters.Add("@verse", SqlDbType.VarChar, 3900).Value = bible.verse;

                    // Open the connection
                    cn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    cn.Close();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                }
            }

            catch (SqlException e)
            {
                throw e;
            }

            return false;
        }

        //method to find bible verse
        public BibleModel findBibleVerse(SearchModel bible)
        {
            //bool result = false;
            try
            {
                // Setup SELECT query with parameters
                string query = "SELECT * FROM dbo.Bible WHERE testament=@testament AND book=@book AND chapter=@chapter AND verseNo=@verseNo";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@testament", SqlDbType.VarChar, 50).Value = bible.testament;
                    cmd.Parameters.Add("@book", SqlDbType.VarChar, 50).Value = bible.bookName;
                    cmd.Parameters.Add("@chapter", SqlDbType.Int, 50).Value = bible.chapterNo;
                    cmd.Parameters.Add("@verseNo", SqlDbType.Int, 50).Value = bible.verseNo;

                    // Open the connection
                    cn.Open();

                    // Using a DataReader see if query returns any rows
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        return new BibleModel(reader["testament"].ToString(), reader["book"].ToString(), int.Parse(reader["chapter"].ToString()), int.Parse(reader["verseNo"].ToString()), reader["verse"].ToString());

                    }


                    // Close the connection
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result of finder
            return null;
        }
    }
}