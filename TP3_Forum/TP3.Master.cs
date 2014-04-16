using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3_Forum
{
    public partial class TP3 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((string)Session["loginName"]) != null && !((string)Session["loginName"]).Equals(""))
            {
                rightBar.InnerHtml = "<a href=\"?disconnect=1\">" + (string)Session["loginName"] + " disconnect</a>";
            }

            string paramDisconnect = Request.QueryString["disconnect"];
            if (paramDisconnect != null)
            {
                Session["loginName"] = "";
                Response.Redirect("Default.aspx");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //TODO: Query the database and verify user information.
            //      When logged in, remove the log in form and add a disconnect button.
            //      Show the user's name at the top.
            //      Users that are logged in can create threads and post messages to threads.
            OleDbConnection oleDbConnection = null;
            try
            {
                oleDbConnection = getDatabaseConnection();

                string query = "SELECT MotDePasse, Pseudo FROM Utilisateurs WHERE Courriel = \"" + txtEmail.Text + "\";";
                OleDbCommand oleDbCommand = new OleDbCommand(query, oleDbConnection);
                OleDbDataReader monDataReader = oleDbCommand.ExecuteReader();
                monDataReader.Read();
                string result = monDataReader[0] + "";
                if (result.Equals(txtPassword.Text))
                {
                    Session["loginName"] = monDataReader[1] + "";
                    Response.Redirect("Default.aspx");
                }
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
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Session["email"] = txtEmail.Text;
            Session["password"] = txtPassword.Text;

            Response.Redirect("Register.aspx");
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