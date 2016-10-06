using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace DeninsonLirianoPrimerParcial.RegistroMaterial
{
    public partial class PagRegistroMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            razonTextBox.Text = "";
            cantidadTextBox.Text = "";
            MaterialGridView.DataSource = String.Empty;
            MaterialGridView.DataBind();

        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}