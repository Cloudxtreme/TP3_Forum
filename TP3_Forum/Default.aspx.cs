using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3_Forum
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var uri = new Uri(Request.Url.ToString());
            string path = uri.GetLeftPart(UriPartial.Path);

            if (!(((string)Session["loginName"]) != null && !(((string)Session["loginName"]).Equals(""))))
            {
                post.InnerHtml = "";
            }

            string paramDisconnect = Request.QueryString["disconnect"];
            if (paramDisconnect != null)
            {
                Session["loginName"] = "";
                Response.Redirect("Default.aspx");
            }

            string paramThread = Request.QueryString["thread"];
            if (paramThread != null)
            {
                test.Text += loadThread(Convert.ToInt32(paramThread));
            }
            else
            {
                test.Text = "<div class=\"jumbotron\"><div class=\"container\"><h1>Bienvenue Pirates!</h1><p>C'est le temps de se parler!</p></div></div>";
                test.Text += loadIndex();
                post.InnerHtml = "";
                if (((string)Session["loginName"]) != null && !((string)Session["loginName"]).Equals(""))
                {
                    test.Text += "<h2><a href=\"NewThread.aspx\">Créer un nouveau sujet!</a></h2>";
                }

            }
        }

        private string loadIndex()
        {
            OleDbConnection oleDbConnection = null;
            try
            {
                oleDbConnection = getDatabaseConnection();

                string indexHtml = "";

                string query = "SELECT Titre, Auteur, DateCreation, ID FROM Sujets;";
                OleDbCommand oleDbCommand = new OleDbCommand(query, oleDbConnection);
                OleDbDataReader monDataReader = oleDbCommand.ExecuteReader();

                while (monDataReader.Read())
                {
                    indexHtml += "<div class=\"row show-grid\">";
                    indexHtml += "<div class=\"col-md-4 col-left\"><h4><a href=\"?thread=" + monDataReader[3] +"\">" + monDataReader[0] + "</a></h4></div>";
                    indexHtml += "<div class=\"col-md-4 col-middle\"><h4>" + monDataReader[1] + "</h4></div>";
                    indexHtml += "<div class=\"col-md-4 col-right\"><h4>" + GetPrettyDate((DateTime)monDataReader[2]) + "</h4></div>";
                    indexHtml += "</div>";
                }

                return indexHtml;
            }
            catch (Exception ex)
            {
                return "Commande ratée: " + ex.Message;
            }
            finally
            {
                if (oleDbConnection != null)
                {
                    oleDbConnection.Close();
                }
            }
        }

        private string loadThread(int index)
        {
            OleDbConnection oleDbConnection = null;
            try
            {
                oleDbConnection = getDatabaseConnection();

                string indexHtml = "";

                string query = "SELECT Auteur, DateCreation, (SELECT Avatar From Utilisateurs WHERE Pseudo = Auteur), Texte FROM Messages WHERE Sujet = " + index + ";";
                OleDbCommand oleDbCommand = new OleDbCommand(query, oleDbConnection);
                OleDbDataReader monDataReader = oleDbCommand.ExecuteReader();

                while (monDataReader.Read())
                {
                    indexHtml += "<div class=\"row\">";
                    indexHtml += "<div class=\"col-md-2 threadCenter\">" + monDataReader[0] + "</div>";
                    indexHtml += "<div class=\"col-md-10 threadCenter\">" + GetPrettyDate((DateTime)monDataReader[1]) + "</div>";
                    indexHtml += "<div class=\"col-md-2 hidden-xs hidden-sm avatar\"><img src=\"assets/img/" + monDataReader[2] + "\"/></div>";
                    indexHtml += "<div class=\"col-md-10\">" + monDataReader[3] + "</div>";
                    indexHtml += "</div>";
                }

                query = "SELECT Titre FROM Sujets WHERE ID = " + index + ";";
                oleDbCommand = new OleDbCommand(query, oleDbConnection);
                monDataReader = oleDbCommand.ExecuteReader();
                monDataReader.Read();
                indexHtml = "<h1>" + monDataReader[0] + "</h1>" + indexHtml;

                return indexHtml;
            }
            catch (Exception ex)
            {
                return "Commande ratée: " + ex.Message;
            }
            finally
            {
                if (oleDbConnection != null)
                {
                    oleDbConnection.Close();
                }
            }
        }
        protected void btnNouveauMessage_Click(object sender, EventArgs e)
        {

            string texte = txtMessage.InnerText;
            string paramThread = Request.QueryString["thread"];
            int indexSujet = Convert.ToInt32(paramThread);
            string username = (string)Session["loginName"];

            OleDbConnection connection = getDatabaseConnection();
            string query = "INSERT INTO Messages (Sujet, Texte, Auteur, DateCreation) VALUES (\"" + indexSujet + "\", \"" + texte + "\", \"" + username + "\", #" + DateTime.Now + "#);";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Votre message a été posté.')</script>");
            Response.Redirect("Default.aspx?" + indexSujet);
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

        //Source: http://www.dotnetperls.com/pretty-date
        static string GetPrettyDate(DateTime d)
        {
            // 1.
            // Get time span elapsed since the date.
            TimeSpan s = DateTime.Now.Subtract(d);

            // 2.
            // Get total number of days elapsed.
            int dayDiff = (int)s.TotalDays;

            // 3.
            // Get total number of seconds elapsed.
            int secDiff = (int)s.TotalSeconds;

            // 4.
            // Don't allow out of range values.
            if (dayDiff < 0 || dayDiff >= 31)
            {
                return null;
            }

            // 5.
            // Handle same-day times.
            if (dayDiff == 0)
            {
                // A.
                // Less than one minute ago.
                if (secDiff < 60)
                {
                    return "just now";
                }
                // B.
                // Less than 2 minutes ago.
                if (secDiff < 120)
                {
                    return "1 minute ago";
                }
                // C.
                // Less than one hour ago.
                if (secDiff < 3600)
                {
                    return string.Format("{0} minutes ago",
                        Math.Floor((double)secDiff / 60));
                }
                // D.
                // Less than 2 hours ago.
                if (secDiff < 7200)
                {
                    return "1 hour ago";
                }
                // E.
                // Less than one day ago.
                if (secDiff < 86400)
                {
                    return string.Format("{0} hours ago",
                        Math.Floor((double)secDiff / 3600));
                }
            }
            // 6.
            // Handle previous days.
            if (dayDiff == 1)
            {
                return "yesterday";
            }
            if (dayDiff < 7)
            {
                return string.Format("{0} days ago",
                dayDiff);
            }
            if (dayDiff < 31)
            {
                return string.Format("{0} weeks ago",
                Math.Ceiling((double)dayDiff / 7));
            }
            return null;
        }
    }
}