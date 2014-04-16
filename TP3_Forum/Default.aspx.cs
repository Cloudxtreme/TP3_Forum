﻿using System;
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
                    indexHtml += "<div class=\"col-md-4 col-right\"><h4>" + monDataReader[2] + "</h4></div>";
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
                    indexHtml += "<div class=\"col-md-10 threadCenter\">" + monDataReader[1] + "</div>";
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