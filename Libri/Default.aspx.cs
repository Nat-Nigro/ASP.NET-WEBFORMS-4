using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Libri
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDb"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT Id, Titolo FROM CollezioneLibri", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader["Id"].ToString();
                    string titolo = reader["Titolo"].ToString();

                    Libri.InnerHtml += $"<p>{titolo} <a href='Dettaglio.aspx?libroId={id}' class='btn btn-primary'>Dettagli</a></p> ";
                }
            }
            catch
            {
                Libri.InnerHtml = "<p>Errore, ricontrolla il codice</p>";
            }
            finally
            {
                conn.Close();
            }
        }
    }
}