using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TP3_Forum
{
    public partial class Register : System.Web.UI.Page
    {
        private int height;
        private int width;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                height = Convert.ToInt32(ConfigurationManager.AppSettings.Get("RequiredHeight"));
                width = Convert.ToInt32(ConfigurationManager.AppSettings.Get("RequiredWidth"));
            }
        }
        protected void btnFinishRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtRegEmail.Text;
            string password = txtRegPassword.Text;
            string filePath = avatar.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            if (filename != "")
            {
                string ext = Path.GetExtension(filename);
                string contenttype = String.Empty;
                FileUpload fileUpload1 = avatar;
                fileUpload1.SaveAs(Server.MapPath("~/assets/img/") + filename);

                switch (ext)
                {
                    case ".jpg":
                        contenttype = "image/jpg";
                        break;
                    case ".png":
                        contenttype = "image/png";
                        break;
                    case ".gif":
                        contenttype = "image/gif";
                        break;
                }
                if (contenttype != String.Empty && ValidateFileDimensions())
                {
                    OleDbConnection connection = getDatabaseConnection();
                    string query = "INSERT INTO Utilisateurs (Pseudo, Courriel, MotDePasse, Avatar) VALUES (\"" + username + "\", \"" + email + "\", \"" + password + "\", \"" + filename + "\");";
                    OleDbCommand cmd = new OleDbCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Votre inscription a été soumise. Bienvenue!')</script>");
                    Response.Redirect("Default.aspx");
                }
            }
            else if (filename == "")
            {
                string avatarDefault = "Default.png";
                OleDbConnection connection = getDatabaseConnection();
                string query = "INSERT INTO Utilisateurs (Pseudo, Courriel, MotDePasse, Avatar) VALUES (\"" + username + "\", \"" + email + "\", \"" + password + "\", \"" + avatarDefault + "\");";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Votre inscription a été soumise. Bienvenue!')</script>");
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Veuillez utiliser une image de format JPG, PNG, ou GIF de 180 pixels par 180 pixels.";
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
        public bool ValidateFileDimensions()
        {
            using (System.Drawing.Image imageAvatar = System.Drawing.Image.FromStream(avatar.PostedFile.InputStream))
            {
                return (imageAvatar.Height == height && imageAvatar.Width == width);
            }
        }
    }
    
}