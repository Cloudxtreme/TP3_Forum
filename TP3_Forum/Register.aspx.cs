using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TP3_Forum
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Text = (string)Session["email"];
            txtPassword.Text = (string)Session["password"];
        }
        protected void btnFinishRegister_Click(object sender, EventArgs e)
        {
            Session["username"] = txtUsername.Text;
            Session["email"] = txtEmail.Text;
            Session["password"] = txtPassword.Text;

            string query = "INSERT INTO Reservation (DateReservation, IDUsager, IDLivre) VALUES (2014-04-11, 3, 3);";
            
            executeNonQuery(query, lblResult);
            //TODO: Validate user input and add it the the database. Then confirm it has been added.

            Response.Redirect("Default.aspx");
        }
        private OleDbConnection getDatabaseConnection()
        {
            OleDbConnection oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(@"assets/database/Weak End.accdb");
            oleDbConnection.Open();
            return oleDbConnection;
        }

        private void executeNonQuery(string query, Label lblResult)
        {
            OleDbConnection oleDbConnection = null;
            try
            {
                oleDbConnection = getDatabaseConnection();
                OleDbCommand oleDbCommand = new OleDbCommand(query, oleDbConnection);
                lblResult.Text = "Commande exécutée: " + oleDbCommand.ExecuteNonQuery() + " lignes affectées";
            }
            catch (Exception ex)
            {
                lblResult.Text = "Commande ratée: " + ex.Message;
            }
            finally
            {
                if (oleDbConnection != null)
                {
                    oleDbConnection.Close();
                }
            }
        }
    }
    
}