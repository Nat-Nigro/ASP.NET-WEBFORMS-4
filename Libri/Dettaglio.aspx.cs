using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Libri
{
    public partial class Dettaglio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string libroId = Request.QueryString["Id"];
                if (libroId != null)
                {

                    string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDb"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connectionString);
                    {

                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("SELECT * FROM CollezioneLibri  WHERE ID = @LibroId", conn);
                            cmd.Parameters.AddWithValue("@LibroId", libroId);
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {

                                Label1.Text = reader["Titolo"].ToString();

                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }
    }
}