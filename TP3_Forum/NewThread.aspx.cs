using System;
using System.Collections.Generic;
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
    }
}