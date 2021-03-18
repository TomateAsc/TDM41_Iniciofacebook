using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

namespace Inicio_con_facebook
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string id_app = "541742410122948";
        string codigo = "";
        string id_secret = "b9b2c0f2e075f18979bf4f1cd7439e19";

        protected void Page_Load(object sender, EventArgs e)
        { 
            codigo = Request.QueryString["code"];
            Response.Write(obtener_acceso(codigo));

        }

        private string obtener_acceso(string code)
        {
            //Uri es una direccion url
            Uri dir = new Uri("https://graph.facebook.com/v4.0/oauth/access_token?client_id=" + id_app + "&redirect_uri=https://localhost:" + Request.ServerVariables["SERVER_PORT"] + "/WebForm2.aspx&client_secret=" + id_secret + "&code=" + code);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(dir);
            req.Method = "POST" ;
            StreamReader entrada_datos= new StreamReader(req.GetResponse().GetResponseStream());
            string token = entrada_datos.ReadToEnd().ToString().Replace("access_token=", "");

            return token;
        }
    }
}