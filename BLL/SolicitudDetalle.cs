using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace BLL
{
    public class SolicitudDetalle
    {

        public int SolicitudDetalleId { get; set; }
        public string Material { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }


        public SolicitudDetalle()
        {
            this.SolicitudDetalleId = 0;
            this.Material = " ";
            this.Cantidad = 0;
            this.Precio = 0;
        }

        public SolicitudDetalle(string Material,int Cantidad,float Precio)
        {
            this.Material = Material;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
        }
    }
}
