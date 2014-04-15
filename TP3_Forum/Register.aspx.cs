using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            
            //TODO: Validate user input and add it the the database. Then confirm it has been added.

            Response.Redirect("Default.aspx");
        }
    }
}