using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3_Forum
{
    public partial class NewThread : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(((string)Session["loginName"]) != null && !((string)Session["loginName"]).Equals("")))
            {
                newThreadVerify.InnerHtml = "<p>Vous devez être connecté pour créer un nouveau sujet!</p>";
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            OleDbConnection oleDbConnection = null;
            try
            {
                oleDbConnection = getDatabaseConnection();

                string query = "INSERT INTO Sujets ( Titre, Auteur, DateCreation) VALUES (\"" + txtTitle.Text + "\", \"" + (string)Session["loginName"] + "\", DATE());";
                OleDbCommand oleDbCommand = new OleDbCommand(query, oleDbConnection);
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (oleDbConnection != null)
                {
                    oleDbConnection.Close();
                }
            }
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