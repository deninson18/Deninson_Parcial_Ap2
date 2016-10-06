using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
   public abstract class ClaseMaestra
    {
        public abstract bool insertar();
        public abstract bool modificar();
        public abstract bool eliminar();
        public abstract bool buscar(int Buscado);
        public abstract DataTable Listado(string Campos, string Condicion, string Orden);

    }
}
