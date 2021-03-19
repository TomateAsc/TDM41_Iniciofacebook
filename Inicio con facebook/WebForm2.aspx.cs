using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using static Inicio_con_facebook.facebook_json;

namespace Inicio_con_facebook
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string id_app = "541742410122948";
        string codigo = "";
        string id_secret = "b9b2c0f2e075f18979bf4f1cd7439e19";
        string acc_tok = "";
        string json_usuario = "";
        string datos_usuario_name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
            codigo = Request.QueryString["code"];
            //Response.Write(obtener_acceso(codigo));
            acc_tok = (obtener_acceso(codigo));
            //Response.Write(obtener_info(acc_tok));
            json_usuario = obtener_info(acc_tok);
            usuario datos_usuario =  JsonConvert.DeserializeObject<usuario>(json_usuario);
            //Response.Write(datos_usuario.name);
            
            datos_usuario_name = nombre(datos_usuario.name);
            lbl.Text = datos_usuario_name;
            this.Panel1.Controls.Add(lbl);
        }

        private string obtener_acceso(string code)
        {
            //Uri es una direccion url
            Uri dir = new Uri("https://graph.facebook.com/v4.0/oauth/access_token?client_id=" + id_app + "&redirect_uri=https://localhost:" + Request.ServerVariables["SERVER_PORT"] + "/WebForm2.aspx&client_secret=" + id_secret + "&code=" + code);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(dir);
            req.Method = "POST" ;
            StreamReader entrada_datos= new StreamReader(req.GetResponse().GetResponseStream());    //flijo de entrada de datos
            string token = entrada_datos.ReadToEnd().ToString().Replace("access_token=", "");
            tok class_token = JsonConvert.DeserializeObject<tok>(token);
            return class_token.access_token;
        }

        private string obtener_info(string a_token)
        {
            string url = "https://graph.facebook.com/me?access_token=" + a_token + "&fields=id,name";
            WebClient cliente = new WebClient();
            Stream datos = cliente.OpenRead(url);
            StreamReader info = new StreamReader(datos);
            string json_datos_usuario = info.ReadToEnd();
            datos.Close();
            info.Close();
            return json_datos_usuario;
        }
        private string nombre(string i)
        {
            string x = "<h1>";
            x += "Bienvenido ";
            x += "</h1>";
            x += "<h1>";
            x += i;
            x += "</h1>";
            return x;
        }
    }
}