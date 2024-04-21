using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;
using Proyecto_Rest_Minor.CSD;

namespace Proyecto_Rest_Minor.CSU
{
    public partial class ConsultaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnConsultar_Click(object sender, EventArgs e)
        {
            RestClient cliente = new RestClient("https://randomuser.me/api/");
            string Respuesta;

            RestRequest request = new RestRequest();
            var response = cliente.Get(request);

            Respuesta = response.Content;

            Resultados oResultado = JsonConvert.DeserializeObject<Resultados>(Respuesta);

            Usuario oUsuario = oResultado.results[0];

            imgUsuario.ImageUrl = oUsuario.picture.large;
            TxtTitulo.Text = oUsuario.name.title;
            TxtNombres.Text = oUsuario.name.first;
            TxtApellidos.Text = oUsuario.name.last;
            TxtUsuario.Text = oUsuario.login.username;
            TxtNombres.Text = oUsuario.name.first;
            TxtPass.Text = oUsuario.login.password;


        }
    }
}