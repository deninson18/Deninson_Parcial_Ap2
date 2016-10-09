using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;



namespace BLL
{
    public class Solicitudes : ClaseMaestra
    {
       // ConexionDb conexion = new ConexionDb();
        public int SolicitudId { get; set; }
        public string Fecha { get; set; }
        public string Razon { get; set; }
        public float Total { get; set; }
        public List<SolicitudDetalle> ListaMaterial { get; set; }

   


        public Solicitudes()
        {
            this.SolicitudId = 0;
            this.Fecha = "";
            this.Razon = "";
            this.Total = 0;
            ListaMaterial = new List<SolicitudDetalle>();

        }
        public void AgregarMaterial(string Material, int Cantidad,float Precio)
        {
            ListaMaterial.Add(new SolicitudDetalle(Material, Cantidad,Precio));
        }


        public override bool insertar()
        {
            ConexionDb conexion = new ConexionDb();
            int retorno = 0;
            try
            {
                retorno = Convert.ToInt32(conexion.ObtenerValor(String.Format("insert into Solicitudes(Fecha,Razon,Total)values('{0}','{1}',{2});select SCOPE_IDENTITY() ", this.Fecha,this.Razon,this.Total)));
               // this.MaterialId = retorno;
                if(retorno > 0)
                {
                    foreach (SolicitudDetalle item in this.ListaMaterial)
                    {
                        conexion.Ejecutar(String.Format("Insert into SolicitudDetalle(MaterialId,Material,Cantidad,Precio) Values ({0},'{1}',{2},{3})",
                            retorno, item.Material, item.Cantidad,item.Precio));
                    }
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return retorno > 0;
            
        }

        public override bool eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("delete from SolicitudDetalle where SolicitudId={0}; delete from Solicitudes where SolicitudId={0}", this.SolicitudId));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public override bool buscar(int Buscado)
        {
            ConexionDb conexion =new  ConexionDb();
            DataTable dt = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(String.Format("select * from Solicitudes where SolicitudId={0}", Buscado));
                if(dt.Rows.Count > 0)
                {
                    this.SolicitudId = (int)dt.Rows[0]["SolicitudId"];
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();
                    this.Razon = dt.Rows[0]["Razon"].ToString();
                    this.Total = (float)Convert.ToDecimal(dt.Rows[0]["Total"].ToString());

                    DataTable dtDetalle = new DataTable();

                    dtDetalle = conexion.ObtenerDatos(String.Format("select * from SolicitudDetalle where SolicitudId={0}", this.SolicitudId));
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        AgregarMaterial((row["Material"].ToString()), (int)row["Cantidad"], (float)Convert.ToDecimal(row["Precio"].ToString()));
                      
                    }

                }
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public override bool modificar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("update solicitudes set Fecha='{0}', Razon='{1}', Total={2} where SolicitudId={3}", this.Razon, this.SolicitudId));
                retorno = conexion.Ejecutar(string.Format("delete from SolicitudDetalle where SolicitudId={0}", this.SolicitudId));

                if (retorno)
                {
                    foreach(SolicitudDetalle mat in this.ListaMaterial)
                    {
                        conexion.Ejecutar(string.Format("insert into SolicitudDetalle(SolicitudId,Material,Cantidad,Precio)values({0},'{1}',{2})", this.SolicitudId, mat.Material, mat.Cantidad,mat.Precio));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

       
        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();

            return conexion.ObtenerDatos("select" + Campos + "from Solicitudes where" + Condicion + " " + Orden);
        }

       
    }
}
