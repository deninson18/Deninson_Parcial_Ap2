using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.ComponentModel;


namespace BLL
{
    public class MaterialDetalle
    {
        ConexionDb conexion =new ConexionDb();
       
        public string Material { get; set; }
        public int Cantidad { get; set; }


        public MaterialDetalle()
        {
            this.Material = "Tela";
            this.Cantidad = 0;
        }

        public MaterialDetalle(string Material,int Cantidad)
        {
            this.Material = Material;
            this.Cantidad = Cantidad;
        }
    }
}
