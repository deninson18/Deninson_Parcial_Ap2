using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;



namespace BLL
{
    public class Registro : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();
        public int MaterialId { get; set; }
        public string Razon { get; set; }
        public List<MaterialDetalle> ListaMaterial { get; set; }

        public Registro()
        {
            this.MaterialId = 0;
            this.Razon = "";
            ListaMaterial = new List<MaterialDetalle>();

        }
        public void AgregarMaterial(string Material, int Cantidad)
        {
            ListaMaterial.Add(new MaterialDetalle(Material, Cantidad));
        }


        public override bool insertar()
        {
            ConexionDb conexion = new ConexionDb();
            int retorno = 0;
            try
            {
                retorno = Convert.ToInt32(conexion.ObtenerValor(string.Format("insert into (Razon)values('{0}');select SCOPE_IDENTITY() ", this.Razon)));
               
                if(retorno > 0)
                {
                    foreach (MaterialDetalle item in this.ListaMaterial)
                    {
                        conexion.Ejecutar(string.Format("Insert into MaterialesDetalle(MaterialId,Material,Cantidad) Values ({0},'{1}',{2})",
                            retorno, item.Material, item.Cantidad));
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
                retorno = conexion.Ejecutar(string.Format("delete from MaterialesDetalle where MaterialId={0}; delete from Materiales where MaterialId={0}", this.MaterialId));

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
                dt = conexion.ObtenerDatos(string.Format("select * from Materiales where MaterialId={0}", Buscado));
                if(dt.Rows.Count > 0)
                {
                    this.Razon = dt.Rows[0]["Razon"].ToString();

                    DataTable dtDetalle = new DataTable();

                    dtDetalle = conexion.ObtenerDatos(string.Format("select * from MaterialesDetalle where MaterialId={0}",Buscado));
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        AgregarMaterial((row["Material"].ToString()), (int)row["Cantidad"]);
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
            throw new NotImplementedException();
        }

       
        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            throw new NotImplementedException();
        }

       
    }
}
