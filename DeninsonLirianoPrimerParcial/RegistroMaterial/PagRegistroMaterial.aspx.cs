using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;




namespace DeninsonLirianoPrimerParcial.RegistroMaterial
{
    public partial class PagRegistroMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void CargarDatos(Registro registro)
        {
            registro.Razon = razonTextBox.Text;
            foreach (GridViewRow row in MaterialGridView.Rows)
            {
                registro.AgregarMaterial(row.Cells[0].Text, Convert.ToInt32(row.Cells[1].ToString()));
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            idTextBox.Text = string.Empty;
            razonTextBox.Text = string.Empty;
            cantidadTextBox.Text = string.Empty;
            MaterialGridView.DataSource = String.Empty;
            MaterialGridView.DataBind();

        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            CargarDatos(registro);
            if (idTextBox.Text.Length <= 0)
            {
                if (registro.insertar())
                {
                    Response.Write("<cript>alert('Guardo Correctamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error al Guardar')</script>");
                }
            }

            
        }
    }
}