using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace DeninsonLirianoPrimerParcial.RegistroMaterial
{
    public partial class RegistroMateriales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void CargarDatos(Materiales material)
        {
            int Id = 0;
            float precio = 0;
            int.TryParse(idmTextBox.Text, out Id);
            float.TryParse(precioMaTextBox.Text, out precio);
            
            material.MaterialesId=Id;
            material.Descripcion = descripcionTextBox.Text;
            material.Precio = precio;

        }
        public void DevolverDatos(Materiales material)
        {
            idmTextBox.Text = material.MaterialesId.ToString();
            descripcionTextBox.Text = material.Descripcion;
            precioMaTextBox.Text = material.Precio.ToString();
        }

        protected void nmButton_Click(object sender, EventArgs e)
        {
            idmTextBox.Text = string.Empty;
            descripcionTextBox.Text = string.Empty;
            precioMaTextBox.Text = string.Empty;
           
        }

        protected void gmButton_Click(object sender, EventArgs e)
        {
            Materiales material = new Materiales();
            CargarDatos(material);
            if (idmTextBox.Text.Length <= 0)
            {
                if (material.insertar())
                {

                    Response.Write("<cript>alert('Guardo Correctamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error al Guardar')</script>");
                }
            }


        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            Materiales material = new Materiales();
            int id = 0;
            int.TryParse(idmTextBox.Text, out id);
            if (id > 0)
            {
                CargarDatos(material);
                if (material.eliminar())
                {
                    idmTextBox.Text = string.Empty;
                    descripcionTextBox.Text = string.Empty;
                    precioMaTextBox.Text = string.Empty;
                    Response.Write("<script>alert('Elimino Correctamente')</script>");

                }
                else
                {
                    Response.Write("<script>alert('Error al Eliminar')</script>");
                }
            }
        }

        protected void bmButton_Click(object sender, EventArgs e)
        {
            Materiales material = new Materiales();
            int id = 0;
            int.TryParse(idmTextBox.Text, out id);
            if (id > 0)
            {
                if (material.buscar(id))
                {
                    DevolverDatos(material);
                }
                else
                {
                    Response.Write("<script>alert('No Existe Material ID!!')</script>");
                }
            }
        }
    }
}