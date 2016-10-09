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
    public partial class PagRegistroSolicitud: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //Solicitudes registro = new Solicitudes();
           
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                CargarDropDList();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Material"), new DataColumn("Cantidad"),new DataColumn("Precio") });
                Session["Materiales"]=dt;
            }
        }

        public void CargarDatos(Solicitudes registro)
        {
            int id = 0;
            float total = 0;
            int.TryParse(idTextBox.Text, out id);
            float.TryParse(TotalTextBox.Text, out total);
   
            registro.SolicitudId = id;

            registro.Razon = razonTextBox.Text;
            registro.Fecha = fechaTextBox.Text;
            registro.Total = total;

            foreach (GridViewRow row in MaterialGridView.Rows)
            {
                registro.AgregarMaterial(row.Cells[0].Text, int.Parse(row.Cells[1].Text),(float)Convert.ToDecimal(row.Cells[2].Text));
            }
        }
        public void DevolverDatos(Solicitudes registro)
        {
            idTextBox.Text = registro.SolicitudId.ToString();
            fechaTextBox.Text = registro.Fecha;
            razonTextBox.Text = registro.Razon;
            TotalTextBox.Text = registro.Total.ToString();
            foreach (var item in registro.ListaMaterial)
            {
                DataTable dt = (DataTable)Session["Materiales"];
                dt.Rows.Add(item.Material, item.Cantidad, item.Precio);
                Session["Materiales"] = dt;
                MaterialGridView.DataSource = Session["Materiales"];
                MaterialGridView.DataBind();
            }

        }
        private void CargarDropDList()
        {
            Materiales material = new Materiales();
            materialDropDownList.DataSource = material.Listado("Descripcion", "1=1", "");
            materialDropDownList.DataTextField = "Descripcion";
            materialDropDownList.DataValueField = "Descripcion";
            materialDropDownList.DataBind();
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
            Solicitudes registro = new Solicitudes();
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
            float total = 0, suma = 0, resultado = 0;
            
            DataTable dt = (DataTable)Session["Materiales"];
            dt.Rows.Add(materialDropDownList.SelectedValue, cantidadTextBox.Text,precioTextBox.Text);
            Session["Materiales"] = dt;
            MaterialGridView.DataSource = dt;
            MaterialGridView.DataBind();
            
            foreach (GridViewRow row in MaterialGridView.Rows)
            {
                suma = suma + (float)Convert.ToDecimal(row.Cells[1].Text);
                total = total + (float)Convert.ToDecimal(row.Cells[2].Text);

            }
            resultado = suma * total;
            precioTextBox.Text = string.Empty;
            cantidadTextBox.Text = string.Empty;
            TotalTextBox.Text = resultado.ToString();
            

            //materialTextBox.Text = string.Empty;
            cantidadTextBox.Text = string.Empty;
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            Solicitudes registro = new Solicitudes();
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

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            Solicitudes registro = new Solicitudes();
            int id = 0;
            int.TryParse(idTextBox.Text, out id);
            if(id> 0)
            {
              //  registro =id;
                if (registro.eliminar())
                {
                    Response.Write("<script>alert('Elimino Correctamente')</script>");

                }
                else
                {
                    Response.Write("<script>alert('Error al Eliminar')</script>");
                }
            }
        }
    }
}