using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inicio_con_facebook
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string id_app = "541742410122948";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.facebook.com/dialog/oauth/?client_id="+id_app+"&redirect_uri=https://localhost:"+ Request.ServerVariables["SERVER_PORT"] +"/WebForm2.aspx&state=1&responce_type=code" );

        }
    }
}