using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Maxi_PC.Helpers;
using System.Data;

namespace TP_Maxi_PC.Repositorios
{
    class OrdenesRepositorio
    {
        private acceso_BD BD;

        public OrdenesRepositorio()
        {
            BD = acceso_BD.Singleton();
        }

        public DataTable obtenerOS()
        {
            string sql = "SELECT * FROM OrdenesServicio";
            return BD.consulta(sql);
        }
        public bool cargarOS(string legajo,string monto,DateTime ingreso, DateTime estimada, string total,string idPC)
        {
            string sql = $"INSERT [dbo].[OrdenesServicio] ([legajoEmpleado],[montoSeña],[fechaIngreso],[fechaEstimadaEntrega],[costoTotal],[idPC]) VALUES ('{legajo}','{monto}','{ingreso.ToString("yyyy-MM-dd")}','{estimada.ToString("yyyy-MM-dd")}','{total}','{idPC}')";
            return BD.EjecutarSQL(sql);
        }
        public void entregar(string id)
        {
            string sql = "UPDATE [dbo].[OrdenesServicio] SET fechaRealEntrega = '" + DateTime.Today.ToString("yyyy-MM-dd")+ "' WHERE idOrdenServicio =" + id;
            BD.EjecutarSQL(sql);
        }
        public bool eliminarOS(string id)
        {
            string sql = "DELETE [dbo].[OrdenesServicio] WHERE idOrdenServicio = " + id;
            return BD.EjecutarSQL(sql);
        }
    }
}
