using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;




namespace DeninsonLirianoPrimerParcial.RegistroMaterial
{
    public partial class PagRegistroMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            DataTable dt = new DataTable();
            if (!IsPostBack)
            {
                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Material"), new DataColumn("Cantidad") });
                Session["Materiales"]=dt;
            }
        }

        public void CargarDatos(Registro registro)
        {
            registro.Razon = razonTextBox.Text;
            foreach (GridViewRow row in MaterialGridView.Rows)
            {
                registro.AgregarMaterial(row.Cells[0].Text, Convert.ToInt32(row.Cells[1].Text));
            }
        }
        public void DevolverDatos(Registro registro)
        {
            razonTextBox.Text = registro.Razon;
            MaterialGridView.DataSource = registro.ListaMaterial;
            MaterialGridView.DataBind();
            
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

        protected void Agregar_Click(object sender, EventArgs e)
        {
            //Registro registo = new Registro();
            DataTable dt = (DataTable)Session["Materiales"];
            dt.Rows.Add(materialTextBox.Text, cantidadTextBox.Text);
            Session["Materiales"] = dt;
            MaterialGridView.DataSource = dt;
            MaterialGridView.DataBind();

            materialTextBox.Text = string.Empty;
            cantidadTextBox.Text = string.Empty;
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            int id = 0;
            int.TryParse(idTextBox.Text, out id);
            if(id > 0)
            {
                if (registro.buscar(id))
                {
                    DevolverDatos(registro);
                }
                else
                {
                    Response.Write("<script>alert('No Existe Material ID!!')</script>");
                }
            }

        }
    }
}